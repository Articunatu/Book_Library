using Book_Library.Models;
using Book_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Service
{
    public interface IDbContext<T>
    {
        Task<T> Create(T created);
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadSingle(int id);
        Task<T> Update(T updated, int id);
        Task<T> Delete(T deleted);
    }

    public interface IBook
    {
        BookViewModel BooksAuthors(int id);
    }

    public interface IBorrower
    {
        LoanCard ReadAllBurrowersLoans(int id);
    }
}
