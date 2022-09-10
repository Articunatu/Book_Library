using Book_Library.Models;
using System.Collections.Generic;

namespace Book_Library.ViewModels
{
    public class LoanViewModel
    {
        public IEnumerable<Book> BurrowedBook { get; set; }
        public IEnumerable<Loan> Loan { get; set; }
    }
}