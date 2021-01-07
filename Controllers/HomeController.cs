using Bookshop.Interfaces;
using Bookshop.Models;
using Bookshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bookshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService; 

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index(string searching)
        {
            if (!string.IsNullOrEmpty(searching))
            {
                return View(bookService.FindByTitle(searching));
            }
            else
            {
                return View(bookService.GetAllBooks().ToList());
            }

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

        //[HttpGet]
        public ActionResult Update(int? id)
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

        [HttpPost]
        public ActionResult Update(int id, Book book)
        {
            // var idbok = bookService.GetBookById((int)id);
           // var book = bookService.GetBookById(id);
            if (!ModelState.IsValid)
            {
                return View("Update", book);
            }
            else
            {
                bookService.UpdateBook(book, id);
                return RedirectToAction("Index");
            }
        }

        public RedirectToRouteResult Delete(int? id)
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
                ModelState.Clear();
                return View();   
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}