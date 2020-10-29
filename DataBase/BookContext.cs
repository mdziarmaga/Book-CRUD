using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookshop.DataBase
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookConnectionString")
        {

        }
    }
}