using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.ViewModels
{
    public class LoanCard
    {
        public ICollection<LoanViewModel> LoanCards { get; set; }
    }
}
