using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookStorage.Business.DTO;
using BookStorage.Business.Interfaces;
using BookStorage.Web.Ui.Models;

namespace BookStorage.Web.Ui.Controllers
{
    public class BooksController : ApiController
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/<controller>
        public IEnumerable<BookViewModel> Get()
        {
            return Mapper.Map<IEnumerable<BookDTO>, IEnumerable<BookViewModel>>(_bookService.GetAllBooks());
        }

        // GET api/<controller>/5
        public BookViewModel Get(int id)
        {
            return Mapper.Map<BookDTO, BookViewModel>(_bookService.FindBook(id));
        }

        // POST api/<controller>
        public void Post([FromBody]BookViewModel value)
        {
            _bookService.AddBook(Mapper.Map<BookViewModel, BookDTO>(value));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]BookViewModel value)
        {
            _bookService.UpdateBook(Mapper.Map<BookViewModel, BookDTO>(value));
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}