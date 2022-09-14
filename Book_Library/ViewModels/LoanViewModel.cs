using Book_Library.Models;
using System.Collections.Generic;

namespace Book_Library.ViewModels
{
    public class LoanViewModel
    {
        public ICollection<Book> BurrowedBook { get; set; }
        public ICollection<Loan> Loan { get; set; }
    }
}