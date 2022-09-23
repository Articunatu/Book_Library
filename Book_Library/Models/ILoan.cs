using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public interface ILoan
    {
        Task<Loan> Create(Loan createdLoan);
    }
}
