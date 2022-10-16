using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Borrower
    {
        [Key]
        public int BorrowerID { get; set; }
        [Required(ErrorMessage = "En lånetagare måste ha ett förnamn!")]
        [StringLength(15, ErrorMessage = "Ett förnamn kan bestå utav max 15 bokstäver!")]
        [MinLength(1, ErrorMessage = "Ett förnamn måste bestå utav minst 1 bokstav!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "En lånetagare måste ha ett efternamn!")]
        [StringLength(15, ErrorMessage = "Ett efternamn kan bestå utav max 15 bokstäver!")]
        [MinLength(2, ErrorMessage = "Ett efternamn måste bestå utav minst 2 bokstäver!")]
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "En lånetagare måste ha ett personnummer!")]
        public string SecurityNumber { get; set; }
        public ICollection<Loan> BorrowedBooks { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
