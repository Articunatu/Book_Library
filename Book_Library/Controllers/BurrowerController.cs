using Microsoft.AspNetCore.Mvc;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Library.ViewModels;
using Book_Library.Service;

namespace Book_Library.Controllers
{
    public class BurrowerController : Controller
    {
        private readonly IBurrower _burrower;
        readonly ILibrary<Burrower> _library;

        public BurrowerController(IBurrower burrower, ILibrary<Burrower> library)
        {
            _burrower = burrower;
            _library = library;
        }

        public ActionResult<Burrower> CreateBurrower()
        {
            return View();
        }

        //[Route("Default/Insert")]

        [HttpPost]
        public async Task<ActionResult<Burrower>> CreateBurrower(Burrower burrower)
        {
            await _library.Create(burrower);
            return View();
        }

        public async Task<ActionResult<Burrower>> AllBurrowers()
        {
            BurrowerViewModel burrowerViewModel = new BurrowerViewModel();
            burrowerViewModel.Burrowers = await _library.ReadAll();
            return View(burrowerViewModel);
        }

        public async Task<ActionResult<Burrower>> ChosenBurrower(int id)
        {
            var burrower = await _library.ReadSingle(id);
            return View(burrower);
        }

        public ActionResult<LoanCard> Loans(int id)
        {
            LoanCard BurrowedBooks = _burrower.ReadAllBurrowersLoans(id);

            if (BurrowedBooks == null)
            {
                return NotFound("That burrower has no burrowed books at the moment...");
            }
            return View(BurrowedBooks);
        }

        public async Task<ActionResult<Burrower>> EditBurrower(int id)
        {
            Burrower edited = await _library.ReadSingle(id);
            if (edited != null)
            {
                return View(edited);
            }
            return NotFound("Kunde ej hitta angiven lånetagare...");
        }

        public async Task<ActionResult<Burrower>> SavedEdit(int id, Burrower burrower)
        {
            if (id == 0)
            {
                return NotFound("Ingen lånetagare existerar med ett ID på värdet 0...");
            }
            if (burrower == null)
            {
                return NotFound("Ingen objekt skickades...");
            }

            Burrower editedBurrower = await _library.Update(burrower, id);

            if (editedBurrower != null)
            {
                return View(editedBurrower);
            }

            return NotFound("Kunde ej ändra den angivna lånetagaren...");
        }

        public async Task<ActionResult<Burrower>> DeleteBurrower(int id)
        {
            var deletedBurrower = await _library.ReadSingle(id);

            if (deletedBurrower != null)
            {
                await _library.Delete(deletedBurrower);
                return View(deletedBurrower);
            }
            return NotFound("Kunde ej hitta angiven lånetagare...");
        }
    }
}