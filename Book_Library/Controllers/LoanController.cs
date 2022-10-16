using Book_Library.Models;
using Book_Library.Service;
using Book_Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Controllers
{
    public class LoanController : Controller
    {
        readonly IDbContext<Loan> _context;
        readonly IDbContext<Borrower> _burrower;

        public LoanController(IDbContext<Loan> context, IDbContext<Borrower> burrower)
        {
            _context = context;
            _burrower = burrower;
        }
        
        public async Task<ActionResult<Loan>> CreateLoan()
        {
            LoanViewModel loanViewModel = new LoanViewModel();
            loanViewModel.AllBorrowers =  await _burrower.ReadAll();
            //loanViewModel.AllCopies = 
            return View(loanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan createdLoan)
        {
            await _context.Create(createdLoan);
            return View();
        }

    }
}
