using Book_Library.Models;
using System.Collections.Generic;

namespace Book_Library.Controllers
{
    public class LoanViewModel
    {
        public IEnumerable<Book> BurrowedBook { get; set; }
        public IEnumerable<Loan> Loan { get; set; }
    }
}