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
        BookContext bookContext = new BookContext();

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

        public IQueryable<Book> GetAllBooks()
        {
            return bookContext.Books;
        }

        public Book GetBookById(int id)
        {
            return bookContext.Books.FirstOrDefault(item => item.IdBook == id);
        }

        public void UpdateBook(int id)
        {
            var bookReplace = bookContext.Books.FirstOrDefault(item => item.IdBook == id);
            //bookContext.Books.AddOrUpdate(bookReplace);
            bookContext.Entry(bookReplace).State = EntityState.Modified;
            //bookContext.Books.AddOrUpdate(bookReplace);
            bookContext.SaveChanges();
            //return res;
        }
    }
}