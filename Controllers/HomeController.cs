using Bookshop.DataBase;
using Bookshop.Interfaces;
using Bookshop.Models;
using Bookshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bookshop.Controllers
{
    public class HomeController : Controller
    {
        BookService bookService = new BookService();
        
        //private IBookService bookService;//= new BookService() ;

   
        //public HomeController(IBookService bookService)
        //{
        //    this.bookService = bookService;
        //}

        public ActionResult Index()
        {
            return View(bookService.GetAllBooks().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = bookService.GetBookById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if(id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var book = bookService.DeleteBook((int)id);
        //    if(book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                bookService.DeleteBook((int)id);
                
            }
            return RedirectToAction("Index");
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
                bookService.AddBook(book);
                return View("Insert");   
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}