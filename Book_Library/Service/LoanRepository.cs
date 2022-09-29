using Book_Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class LoanRepository : IDbContext<Loan>
    {
        readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> Create(Loan createdLoan)
        {
            var created = await _context.Loans.AddAsync(createdLoan);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public Task<Loan> Delete(Loan createdLoan)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loan>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Loan> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Loan> Update(Loan createdLoan, int id)
        {
            throw new NotImplementedException();
        }
    }
}
