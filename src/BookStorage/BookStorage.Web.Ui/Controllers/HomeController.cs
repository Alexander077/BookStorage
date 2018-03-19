using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStorage.Business.DTO;
using BookStorage.Business.Interfaces;
using BookStorage.Web.Business.Services;

namespace BookStorage.Web.Ui.Controllers
{
    public class HomeController : Controller
    {
        IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            
            return View();
        }
    }
}
