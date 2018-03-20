using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Business.DTO;

namespace BookStorage.Business.Interfaces
{
    public interface IBookService
    {
        BookDTO FindBook(int id);
        IEnumerable<BookDTO> GetAllBooks();
        int AddBook(BookDTO newBook);
        void DeleteBook(int id);
        void UpdateBook(BookDTO bookToUpdate);
    }
}
