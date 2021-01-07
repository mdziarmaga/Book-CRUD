using Bookshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookshop.DataBase
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext() : base("BookConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BookContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}