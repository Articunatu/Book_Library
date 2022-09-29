using Book_Library.Service;
using Book_Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BurrowerRepository : IDbContext<Burrower>, IBurrower
    {
        private AppDbContext _context;

        public BurrowerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Burrower> Create(Burrower createdBurrower)
        {
            var created = await _context.Burrowers.AddAsync(createdBurrower);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<IEnumerable<Burrower>> ReadAll()
        {
            return await _context.Burrowers.ToArrayAsync();
        }

        public LoanCard ReadAllBurrowersLoans(int burrowerID)
        {
            var burrowersBooks = (from c in _context.Copies
                                  join l in _context.Loans
                                  on c.CopyID equals l.CopyID
                                  join bu in _context.Burrowers
                                  on l.BurrowerID equals bu.BurrowerID
                                  where bu.BurrowerID == burrowerID
                                  select c).Distinct().ToArray();

            LoanCard loanCard = new LoanCard();
            loanCard.LoanCards = new List<LoanViewModel>();

            foreach (var item in burrowersBooks)
            {
                LoanViewModel loanViewModel = new LoanViewModel();

                loanViewModel.BurrowedBook = new Book();
                loanViewModel.Loan = new Loan();

                loanViewModel.BurrowedBook = _context.Books.FirstOrDefault(b => b.BookID == item.BookID);
                loanViewModel.Loan = _context.Loans.FirstOrDefault(l => l.CopyID == item.CopyID);

                loanCard.LoanCards.Add(loanViewModel);
            }

            return loanCard;
        }

        public async Task<Burrower> ReadSingle(int burrowerID)
        {
            return await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID.Equals(burrowerID));
        }

        public async Task<Burrower> Update(Burrower updatedBurrower, int id)
        {
            if (id != 0)
            {
                var updated = await ReadSingle(id);

                updated.FirstName = updatedBurrower.FirstName;
                updated.LastName = updatedBurrower.LastName;
                updated.EMail = updatedBurrower.EMail;
                updated.SecurityNumber = updatedBurrower.SecurityNumber;
                updated.Address = updatedBurrower.Address;

                await _context.SaveChangesAsync();
                return updated;
            }

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Burrower> Delete(Burrower deletedBurrower)
        {
            Burrower deleted = await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID == deletedBurrower.BurrowerID);
            _context.Burrowers.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}
