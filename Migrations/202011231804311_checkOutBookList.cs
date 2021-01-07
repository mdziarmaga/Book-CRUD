namespace Bookshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkOutBookList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Book_IdBook", c => c.Int());
            CreateIndex("dbo.Books", "Book_IdBook");
            AddForeignKey("dbo.Books", "Book_IdBook", "dbo.Books", "IdBook");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Book_IdBook", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Book_IdBook" });
            DropColumn("dbo.Books", "Book_IdBook");
        }
    }
}
