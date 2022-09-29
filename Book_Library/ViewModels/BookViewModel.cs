using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Copy> Copies { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Shelf> Shelves{ get; set; }
    }
}
