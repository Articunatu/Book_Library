using Book_Library.Service;
using Book_Library.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BookRepository : IDbContext<Book>, IBook
    {
        readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book createdBook)
        {
            var created = await _context.Books.AddAsync(createdBook);
            await _context.SaveChangesAsync();
            return created.Entity;
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
                //var loanedCopy = _context.Loans.FirstOrDefault(l => l.CopyID == item.CopyID);
                //if (loanedCopy != null && DateTime.Compare(loanedCopy.DateOfReturn, DateTime.Now) < 0)
                //{
                //    item.BookStatus = Status.Late;
                //}
                bookViewModel.Copies.ToList().Add(item);
            }

            return bookViewModel;
        }

        public async Task<Book> ReadSingle(int bookID)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookID.Equals(bookID));
        }

        public async Task<Book> Update(Book updatedBook, int id)
        {
            if (id != 0)
            {
                var updated = await ReadSingle(id);

                updated.Title = updatedBook.Title;
                updated.Reservation = updatedBook.Reservation;
                updated.Copies = updatedBook.Copies;

                await _context.SaveChangesAsync();
                return updated;
            }

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Book> Delete(Book deletedBook)
        {
            Book deleted = await _context.Books.FirstOrDefaultAsync(b => b.BookID == deletedBook.BookID);
            _context.Books.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}
