using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Data.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }

        [MaxLength(150)]
        [Required]
        public string Authors { get; set; }

        [MaxLength(150)]
        [Required]
        public string PublishingHouse { get; set; }

        [Required]
        public int YearOfPublishing { get; set; }
    }
}
