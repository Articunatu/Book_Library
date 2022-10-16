using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.ViewModels
{
    public class BorrowerViewModel
    {
        public IEnumerable<Borrower> Borrowers { get; set; }
    }
}
