using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStorage.Web.Ui.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(150, ErrorMessage = "Title must be not longer than {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Authors is required")]
        [MaxLength(150, ErrorMessage = "Authors field must be not longer than {1} characters")]
        public string Authors { get; set; }

        [Required(ErrorMessage = "Publishing House is required")]
        [MaxLength(150, ErrorMessage = "Publishing House field must be not longer than {1} characters")]
        public string PublishingHouse { get; set; }

        [Range(1, 9999, ErrorMessage = "Year Of Publishing must be between {1} and {2}")]
        public int YearOfPublishing { get; set; }
    }
}