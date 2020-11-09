using Bookshop.DataBase;
using Bookshop.Interfaces;
using Bookshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Bookshop.Services
{
    public class BookService : IBookService
    {
         BookContext bookContext= new BookContext();

        public Book AddBook(Book book)
        {
            bookContext.Books.Add(book);
            bookContext.SaveChanges();
            return book;
        }

        public Book DeleteBook(int id)
        {
            var bookDelete = bookContext.Books.FirstOrDefault(item => item.IdBook == id);
            var res= bookContext.Books.Remove(bookDelete);
            bookContext.SaveChanges();
            return res;
        }

        public List<Book> FindByTitle(string title)
        {
            return bookContext.Books.Where(item => item.Tittle.Equals(title)).ToList();
        }

        public IQueryable<Book> GetAllBooks()
        {
            return bookContext.Books;
        }

        public Book GetBookById(int id)
        {
            return bookContext.Books.FirstOrDefault(item => item.IdBook == id);
        }

        public bool UpdateBook(Book book)
        {
            bookContext.Books.AddOrUpdate(book);
            bookContext.SaveChanges();
            return true;//res;
        }
    }
}