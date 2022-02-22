using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a correct book name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a correct author name")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage ="Please choose a genre")]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name="Release Date")]
        [Required(ErrorMessage ="Please enter a valid date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Number In Stock")]
        [Range(1, 20, ErrorMessage = "Number in stock must be bettwen 1 and 20")]
        [Required(ErrorMessage = "Please provide number in stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }



    }
}
