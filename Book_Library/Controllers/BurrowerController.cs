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

        public async Task<ActionResult<Burrower>> PostBurrower(Burrower burrower)
        {
            var createdBurrower = await _burrower.Create(burrower);
            return View(createdBurrower);
        }

        public async Task<ActionResult<Burrower>> AllBurrowers()
        {
            var burrowers = await _burrower.ReadAll();
            return View(burrowers);
        }

        public async Task<ActionResult<Burrower>> ChosenBurrower(int id)
        {
            var burrower = await _burrower.ReadSingle(id);
            return View(burrower);
        }

        public ActionResult<object> Loans(int id)
        {
            LoanViewModel BurrowedBooks = (LoanViewModel)_burrower.ReadAllBurrowersLoans(id);

            if (BurrowedBooks == null || BurrowedBooks.BurrowedBook.Count == 0)
            {
                return NotFound("That burrower has no burrowed books at the moment...");
            }
            return View((LoanViewModel)BurrowedBooks);
        }

        public async Task<ActionResult<Burrower>> EditBurrower(Burrower burrower)
        {
            var editedburrower = await _burrower.Update(burrower);
            return View(editedburrower);
        }

        public async Task<ActionResult<Burrower>> DeleteBurrower(Burrower burrower)
        {
            var deletedBurrower = await _burrower.Delete(burrower);
            return View(deletedBurrower);
        }
    }
}