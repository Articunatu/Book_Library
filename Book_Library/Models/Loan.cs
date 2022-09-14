using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        [Required(ErrorMessage = "Ett lån måste bestå av ett bok-exemplar!")]
        public int CopyID { get; set; }
        [Required(ErrorMessage = "Ett lån måste ha en lånetagare!")]
        public int BurrowerID { get; set; }
        public DateTime DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int AmountOfLoanRenewals { get; set; }
    }
}
