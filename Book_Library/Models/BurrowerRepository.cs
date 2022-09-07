using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BurrowerRepository : IBurrower
    {
        public Task<Burrower> Create(Burrower createdBurrower)
        {
            throw new NotImplementedException();
        }

        public Task<Burrower> Delete(Burrower deletedBurrower)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task<Burrower>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Burrower> ReadAllBurrowersLoans(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Burrower> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Burrower> Update(Burrower updatedBurrower)
        {
            throw new NotImplementedException();
        }
    }
}
