using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.ViewModels
{
    public class LibraryViewModel
    {
        public ICollection<BookViewModel> BookViewModels { get; set; }
    }
}
