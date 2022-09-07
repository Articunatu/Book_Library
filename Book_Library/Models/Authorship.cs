using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Authorship
    {
        [Key]
        public int AuthorshipID { get; set; }
        public int Authorship_AuthorID { get; set; }
        public int Authorship_BookID { get; set; }
    }
}
