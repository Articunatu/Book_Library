﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class BookCopy
    {
        public int BookID { get; set; }
        public int ShelfID { get; set; }
        public Status BookStatus { get; set; }
    }

    public enum Status
    {
        Available,
        Late,
        Gone,
        Burrowed,
        Reserved
    }
}
