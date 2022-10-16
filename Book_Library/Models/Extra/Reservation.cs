using System;

namespace Book_Library.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BorrowerID { get; set; }
        public int BookID { get; set; }
        public int LocationID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateReserved { get; set; }
    }
}