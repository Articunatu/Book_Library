using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required(ErrorMessage = "En bok måste ha en titel!")]
        [StringLength(25, ErrorMessage = "En boktitel kan max bestå utav 25 bokstäver!")]
        [MinLength(1, ErrorMessage = "En boktitel måste bestå av minst 1 bokstav!")]
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string ThumbnailURL { get; set; }
        public ICollection<Copy> Copies { get; set; }
        public Queue<Reservation> Reservation { get; set; }
    }
}
