using Book_Library.Service;
using Book_Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BorrowerRepository : IDbContext<Borrower>, IBorrower
    {
        private AppDbContext _context;

        public BorrowerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Borrower> Create(Borrower createdBorrower)
        {
            var created = await _context.Borrowers.AddAsync(createdBorrower);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<IEnumerable<Borrower>> ReadAll()
        {
            return await _context.Borrowers.ToArrayAsync();
        }

        public LoanCard ReadAllBurrowersLoans(int borrowerID)
        {
            var borrowersBooks = (from c in _context.Copies
                                  join l in _context.Loans
                                  on c.CopyID equals l.CopyID
                                  join bu in _context.Borrowers
                                  on l.BorrowerID equals bu.BorrowerID
                                  where bu.BorrowerID == borrowerID
                                  select c).Distinct().ToArray();

            LoanCard loanCard = new LoanCard();
            loanCard.LoanCards = new List<LoanViewModel>();

            foreach (var item in borrowersBooks)
            {
                LoanViewModel loanViewModel = new LoanViewModel();

                loanViewModel.BorrowedBook = new Book();
                loanViewModel.Loan = new Loan();

                loanViewModel.BorrowedBook = _context.Books.FirstOrDefault(b => b.BookID == item.BookID);
                loanViewModel.Loan = _context.Loans.FirstOrDefault(l => l.CopyID == item.CopyID);

                loanCard.LoanCards.Add(loanViewModel);
            }

            return loanCard;
        }

        public async Task<Borrower> ReadSingle(int borrowerID)
        {
            return await _context.Borrowers.FirstOrDefaultAsync(b => b.BorrowerID.Equals(borrowerID));
        }

        public async Task<Borrower> Update(Borrower updatedBorrower, int id)
        {
            if (id != 0)
            {
                var updated = await ReadSingle(id);

                updated.FirstName = updatedBorrower.FirstName;
                updated.LastName = updatedBorrower.LastName;
                updated.EMail = updatedBorrower.EMail;
                updated.SecurityNumber = updatedBorrower.SecurityNumber;
                updated.Address = updatedBorrower.Address;

                await _context.SaveChangesAsync();
                return updated;
            }

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Borrower> Delete(Borrower deletedBorrower)
        {
            Borrower deleted = await _context.Borrowers.FirstOrDefaultAsync(b => b.BorrowerID == deletedBorrower.BorrowerID);
            _context.Borrowers.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}
