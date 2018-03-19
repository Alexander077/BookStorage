using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStorage.Business.DTO;
using BookStorage.Business.Interfaces;
using BookStorage.Data.Access.Iterfaces;
using BookStorage.Data.Model;

namespace BookStorage.Web.Business.Services
{
    public class BookService : IBookService
    {
        static BookService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
                //cfg.CreateMap<IEnumerable<Book>, IEnumerable<BookDTO>>();
            });
        }

        IUnitOfWork _db;

        public BookService(IUnitOfWork uof)
        {
            _db = uof;
        }

        public BookDTO FindBook(int id)
        {
            return Mapper.Map<Book, BookDTO>(_db.Books.Find(id));
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return Mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_db.Books.Select());
        }

        public void AddBook(BookDTO newBook)
        {
            Book bookToAdd = Mapper.Map<BookDTO, Book>(newBook);
            _db.Books.Create(bookToAdd);
        }

        public void DeleteBook(int id)
        {
            _db.Books.Delete(_db.Books.Find(id));
        }

        public void UpdateBook(BookDTO bookToUpdate)
        {
            Book book = Mapper.Map<BookDTO, Book>(bookToUpdate);
            _db.Books.Update(book);
        }
    }
}
