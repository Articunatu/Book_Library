using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}
