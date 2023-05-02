using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.ViewModel.Books
{
    public class CreateBookViewModel
    {

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? ISBN { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public List<string>? Genere { get; set; }
    }
}
