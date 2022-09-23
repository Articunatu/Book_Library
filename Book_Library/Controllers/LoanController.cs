using Book_Library.Models;
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
        readonly ILoan _loan;
        readonly IBurrower _burrower;

        public LoanController(ILoan loan, IBurrower burrower)
        {
            _loan = loan;
            _burrower = burrower;
        }
        
        public async Task<ActionResult<Loan>> CreateLoan()
        {
            LoanViewModel loanViewModel = new LoanViewModel();
            loanViewModel.AllBurrowers =  await _burrower.ReadAll();
            return View(loanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan createdLoan)
        {
            await _loan.Create(createdLoan);
            return View();
        }

    }
}
