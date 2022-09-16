using Book_Library.Models;
using System.Collections.Generic;

namespace Book_Library.ViewModels
{
    public class LoanViewModel
    {
        public Book BurrowedBook { get; set; }
        public Loan Loan { get; set; }
    }
}