﻿using Book_Library.Service;
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
        readonly ILibrary<Book> _library;

        public BookController(ILibrary<Book> library, IBook book)
        {
            _book = book;
            _library = library;
        }

        public async Task<ActionResult<Book>> AllBooks()
        {
            IEnumerable<Book> booksInLibrary = await _library.ReadAll();

            LibraryViewModel library = new LibraryViewModel();
            library.BookViewModels = new List<BookViewModel>();

            foreach (var book in booksInLibrary)
            {
                BookViewModel bookViewModel = new BookViewModel();
                //bookViewModel.Authors = new List<Author>();
                bookViewModel = _book.BooksAuthors(book.BookID);

                library.BookViewModels.Add(bookViewModel);
            }
            
            return View(library);
        }

        public ActionResult<Book> SingleBook(int id)
        {
            BookViewModel bookViewModel = _book.BooksAuthors(id);
            return View(bookViewModel);
        }
    }
}
