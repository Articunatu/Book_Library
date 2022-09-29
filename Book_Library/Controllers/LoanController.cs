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
        readonly ILibrary<Loan> _libarary;
        readonly ILibrary<Burrower> _burrower;

        public LoanController(ILibrary<Loan> library, ILibrary<Burrower> burrower)
        {
            _libarary = library;
            _burrower = burrower;
        }
        
        public async Task<ActionResult<Loan>> CreateLoan()
        {
            LoanViewModel loanViewModel = new LoanViewModel();
            loanViewModel.AllBurrowers =  await _burrower.ReadAll();
            //loanViewModel.AllCopies = 
            return View(loanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan createdLoan)
        {
            await _libarary.Create(createdLoan);
            return View();
        }

    }
}
