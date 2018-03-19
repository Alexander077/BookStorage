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
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //BookDTO asd = _bookService.FindBook(1);
            //List<BookDTO> asd = _bookService.GetAllBooks().ToList();

            return View();
        }
    }
}
