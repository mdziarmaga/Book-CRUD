using Bookshop.DataBase;
using Bookshop.Models;
using Bookshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookshop.Controllers
{
    public class HomeController : Controller
    {
        //BookService bs = new BookService();
        BookContext bookContext = new BookContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("Insert", book);
            }
            else
            {
                bookContext.Books.Add(book);
                bookContext.SaveChanges();
                //bs.AddBook(book);
                return View("Insert");
               
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}