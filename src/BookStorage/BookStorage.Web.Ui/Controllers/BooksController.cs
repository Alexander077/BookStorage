﻿using System;
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
        public IHttpActionResult Post([FromBody]BookViewModel value)
        {
            if (ModelState.IsValid)
            {
                int newBookId = _bookService.AddBook(Mapper.Map<BookViewModel, BookDTO>(value));
                return Ok(new {newBookId = newBookId });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]BookViewModel value)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(Mapper.Map<BookViewModel, BookDTO>(value));
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}