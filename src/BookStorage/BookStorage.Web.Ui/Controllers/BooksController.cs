using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStorage.Business.DTO;
using BookStorage.Business.Interfaces;

namespace BookStorage.Web.Ui.Controllers
{
    public class BooksController : ApiController
    {
        IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //TODO: Replace returned DTO with something that fits better
        // GET api/<controller>
        public IEnumerable<BookDTO> Get()
        {
            return _bookService.GetAllBooks();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}