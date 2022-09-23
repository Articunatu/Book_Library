using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class LoanRepository : ILoan
    {
        readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> Create(Loan createdLoan)
        {
            var created = await _context.Loans.AddAsync(createdLoan);
            await _context.SaveChangesAsync();
            return created.Entity;
        }
    }
}
