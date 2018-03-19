using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublishing { get; set; }
    }
}
