using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Shelf
    {
        public int ShelfID { get; set; }
        public string ShelfName { get; set; }
        public ICollection<BookCopy> BooksOfShelf { get; set; }
    }
}