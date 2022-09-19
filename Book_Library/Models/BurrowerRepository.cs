using Book_Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BurrowerRepository : IBurrower
    {
        private LibraryDbContext _context;

        public BurrowerRepository(LibraryDbContext context)
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

                Book book = _context.Books.FirstOrDefault(b => b.BookID == item.BookID);
                Loan loan = _context.Loans.FirstOrDefault(l => l.CopyID == item.CopyID);

                loanViewModel.BurrowedBook = new Book();
                loanViewModel.Loan = new Loan();

                loanViewModel.BurrowedBook = book;
                loanViewModel.Loan = loan;

                loanCard.LoanCards.Add(loanViewModel);
            }

            return loanCard;
        }

        public async Task<Burrower> ReadSingle(int burrowerID)
        {
            return await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID.Equals(burrowerID));
        }

        public async Task<Burrower> Update(Burrower updatedBurrower)
        {
            var updated = await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID.Equals(updatedBurrower.BurrowerID));
            updated.FirstName = updatedBurrower.FirstName;
            updated.LastName = updatedBurrower.LastName;
            updated.EMail = updatedBurrower.EMail;
            updated.Address = updatedBurrower.Address;
            updated.SecurityNumber = updatedBurrower.SecurityNumber;
            await _context.SaveChangesAsync();
            return updated;
        }

        public async Task<Burrower> Delete(Burrower deletedBurrower)
        {
            var deleted = await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID == deletedBurrower.BurrowerID);
            _context.Burrowers.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}
