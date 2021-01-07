namespace Bookshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentedBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Book_IdBook", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Book_IdBook" });
            CreateTable(
                "dbo.RentedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_IdBook = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_IdBook)
                .Index(t => t.Book_IdBook);
            
            DropColumn("dbo.Books", "Book_IdBook");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Book_IdBook", c => c.Int());
            DropForeignKey("dbo.RentedBooks", "Book_IdBook", "dbo.Books");
            DropIndex("dbo.RentedBooks", new[] { "Book_IdBook" });
            DropTable("dbo.RentedBooks");
            CreateIndex("dbo.Books", "Book_IdBook");
            AddForeignKey("dbo.Books", "Book_IdBook", "dbo.Books", "IdBook");
        }
    }
}
