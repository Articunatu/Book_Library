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

        public async Task<Burrower> Delete(Burrower deletedBurrower)
        {
            var deleted = await _context.Burrowers.FirstOrDefaultAsync(b => b.BurrowerID == deletedBurrower.BurrowerID);
            _context.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;

        }

        public async Task<IEnumerable<Burrower>> ReadAll()
        {
            return await _context.Burrowers.ToArrayAsync();
        }

        public async Task<Object> ReadAllBurrowersLoans(int burrowerID)
        {
            var burrowersBooks = (from bo in _context.Books
                                  join l in _context.Loans
                                  on bo.BookID equals l.Loan_BookID
                                  join bu in _context.Burrowers
                                  on l.Loan_BurrowerID equals bu.BurrowerID
                                  where bu.BurrowerID == burrowerID
                                  select bo).Distinct().ToArrayAsync();
            return await burrowersBooks;
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
    }
}
