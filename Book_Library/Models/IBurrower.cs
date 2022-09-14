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
        object ReadAllBurrowersLoans(int id);
        Task<Burrower> Update(Burrower updatedBurrower);
        Task<Burrower> Delete(Burrower deletedBurrower);
    }
}
