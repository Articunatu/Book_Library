using Book_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BookController : Controller
    {
        readonly IBook _book;

        public BookController(IBook book)
        {
            _book = book;
        }

        public async Task<ActionResult<Burrower>> AllBooks()
        {

            LibraryViewModel library = new LibraryViewModel();

            var booksAuthors = _book.BooksAuthorsAsync();

            foreach (var item in booksAuthors)
            {
                item.
            }
            
            return View(library);
        }
    }
}
