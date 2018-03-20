﻿using System;
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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public string PublishingHouse { get; set; }
        [Required]
        public int YearOfPublishing { get; set; }
    }
}
