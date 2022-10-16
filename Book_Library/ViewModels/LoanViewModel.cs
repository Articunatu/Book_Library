using Book_Library.Models;
using System.Collections.Generic;

namespace Book_Library.ViewModels
{
    public class LoanViewModel
    {
        public Book BorrowedBook { get; set; }
        public Loan Loan { get; set; }
        public IEnumerable<Borrower> AllBorrowers { get; set; }
        public IEnumerable<Copy> AllCopies { get; set; }
    }
}