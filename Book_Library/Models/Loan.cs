﻿using System;
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
        [Required(ErrorMessage = "Ett lån måste bestå av en bok!")]
        public int Loan_BookID { get; set; }
        [Required(ErrorMessage = "Ett lån måste ha en lånetagare!")]
        public int Loan_BurrowerID { get; set; }
        public DateTime DateOfLoan { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int AmountOfLoanRenewals { get; set; }
    }
}