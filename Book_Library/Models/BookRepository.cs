using Book_Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BookRepository : IBook
    {
        readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public Task<Book> Create(Book createdBook)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> ReadAll()
        {
            return await _context.Books.ToArrayAsync();
        }

        public BookViewModel BooksAuthors(int bookID)
        {
            var booksAuthors = (from ship in _context.Authorships
                                join au in _context.Authors on
                                ship.AuthorID equals au.AuthorID
                                join bo in _context.Books on
                                ship.BookID equals bo.BookID
                                where bo.BookID == bookID
                                select ship).Distinct().ToArray();

            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Authors = new List<Author>();

            bookViewModel.Book = _context.Books.FirstOrDefault(b => b.BookID == bookID);

            foreach (var item in booksAuthors)
            {
                Author author = _context.Authors.FirstOrDefault(a => a.AuthorID == item.AuthorID);
                bookViewModel.Authors.Add(author);
            }

            bookViewModel.Copies = new List<Copy>();
            var bookCopies = _context.Copies.Where(b => b.BookID == bookID);

            foreach (var item in bookCopies)
            {
                bookViewModel.Copies.ToList().Add(item);
            }

            return bookViewModel;
        }

        public async Task<Book> ReadSingle(int bookID)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookID.Equals(bookID));
        }

        public Task<Book> Update(Book updatedBook)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Delete(Book deletedBook)
        {
            throw new NotImplementedException();
        }
    }
}
