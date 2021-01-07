using Bookshop.DataBase;
using Bookshop.Interfaces;
using Bookshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bookshop.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext bookContext;

        public BookService (BookContext bookContext)
        {
            this.bookContext = bookContext;
        }

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

        public  void UpdateBook(Book book1, int bookId)
        {
            var bookToUpdate = bookContext.Books.FirstOrDefault(item => item.IdBook == bookId);

            bookToUpdate.Author = book1.Author;
            bookToUpdate.Category = book1.Category;
            bookToUpdate.Tittle = book1.Tittle;
            bookToUpdate.ProductionDate = book1.ProductionDate;
            bookContext.SaveChanges();
        }
    }
}