using Microsoft.AspNetCore.Mvc;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Library.ViewModels;

namespace Book_Library.Controllers
{
    public class BurrowerController : Controller
    {
        private IBurrower _burrower;

        public BurrowerController(IBurrower burrower)
        {
            _burrower = burrower;
        }

        public IActionResult Loans(int id)
        {
            IEnumerable<LoanViewModel> BurrowedBooks;
            BurrowedBooks = (IEnumerable<LoanViewModel>)
                _burrower.ReadAllBurrowersLoans(id);

            if (BurrowedBooks == null)
            {
                return NotFound();
            }
            return View(BurrowedBooks);
        }
    }
}
