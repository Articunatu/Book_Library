using System;

namespace Book_Library.Models
{
    public class Reservation
    {
        public int BurrowerID { get; set; }
        public int BookID { get; set; }
        public int LibraryID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateReserved { get; set; }
    }
}