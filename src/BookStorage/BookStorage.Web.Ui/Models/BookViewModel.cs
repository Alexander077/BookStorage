using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStorage.Web.Ui.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublishing { get; set; }
    }
}