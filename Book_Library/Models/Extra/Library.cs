using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Library
    {
        public int LibraryID { get; set; }
        public string LibraryName { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}
