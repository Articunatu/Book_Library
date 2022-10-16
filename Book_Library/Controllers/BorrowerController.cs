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
    public class BorrowerController : Controller
    {
        private readonly IBorrower _borrower;
        readonly IDbContext<Borrower> _context;

        public BorrowerController(IBorrower borrower, IDbContext<Borrower> context)
        {
            _borrower = borrower;
            _context = context;
        }

        public ActionResult<Borrower> CreateBorrower()
        {
            return View();
        }

        //[Route("Default/Insert")]

        [HttpPost]
        public async Task<ActionResult<Borrower>> CreateBorrower(Borrower borrower)
        {
            await _context.Create(borrower);
            return View();
        }

        public async Task<ActionResult<Borrower>> AllBorrowers()
        {
            BorrowerViewModel borrowerViewModel = new BorrowerViewModel();
            borrowerViewModel.Borrowers = await _context.ReadAll();
            return View(borrowerViewModel);
        }

        public async Task<ActionResult<Borrower>> ChosenBorrower(int id)
        {
            var borrower = await _context.ReadSingle(id);
            return View(borrower);
        }

        public ActionResult<LoanCard> Loans(int id)
        {
            LoanCard BorrowedBooks = _borrower.ReadAllBurrowersLoans(id);

            if (BorrowedBooks == null)
            {
                return NotFound("Den lånetagaren har inga lån just nu...");
            }
            return View(BorrowedBooks);
        }

        public async Task<ActionResult<Borrower>> EditBorrower(int id)
        {
            Borrower edited = await _context.ReadSingle(id);
            if (edited != null)
            {
                return View(edited);
            }
            return NotFound("Kunde ej hitta angiven lånetagare...");
        }

        public async Task<ActionResult<Borrower>> SavedEdit(int id, Borrower borrower)
        {
            if (id == 0)
            {
                return NotFound("Ingen lånetagare existerar med ett ID på värdet 0...");
            }
            if (borrower == null)
            {
                return NotFound("Ingen objekt skickades...");
            }

            Borrower editedBorrower = await _context.Update(borrower, id);

            if (editedBorrower != null)
            {
                return View(editedBorrower);
            }

            return NotFound("Kunde ej ändra den angivna lånetagaren...");
        }

        public async Task<ActionResult<Borrower>> DeleteBorrower(int id)
        {
            var deletedBorrower = await _context.ReadSingle(id);

            if (deletedBorrower != null)
            {
                await _context.Delete(deletedBorrower);
                return View(deletedBorrower);
            }
            return NotFound("Kunde ej hitta angiven lånetagare...");
        }
    }
}