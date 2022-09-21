using Book_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public interface IBook
    {
        Task<Book> Create(Book createdBook);
        Task<Book> ReadSingle(int id);
        Task<IEnumerable<Book>> ReadAll();
        BookViewModel BooksAuthors(int id);
        Task<Book> Update(Book updatedBook);
        Task<Book> Delete(Book deletedBook);
    }
}
