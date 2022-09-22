using Book_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public interface IBurrower
    {
        Task<Burrower> Create(Burrower createdBurrower);
        Task<Burrower> ReadSingle(int id);
        Task<IEnumerable<Burrower>> ReadAll();
        LoanCard ReadAllBurrowersLoans(int id);
        Task<Burrower> Update(Burrower updatedBurrower, int id);
        Task<Burrower> Delete(Burrower deletedBurrower);
    }
}
