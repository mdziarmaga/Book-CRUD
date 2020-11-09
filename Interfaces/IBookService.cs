using Bookshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Interfaces
{
    public interface IBookService
    {
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int i);
        Book AddBook(Book book);
        Book DeleteBook(int id);
        bool UpdateBook(Book book);
        List<Book> FindByTitle(string title);
        
    }
}
