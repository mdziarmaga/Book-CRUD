namespace Bookshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ProductionDate", c => c.DateTime());
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AddColumn("dbo.Books", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Books", "CheckOutDate", c => c.DateTime());
            AddColumn("dbo.Books", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ReturnDate");
            DropColumn("dbo.Books", "CheckOutDate");
            DropColumn("dbo.Books", "Category");
            DropColumn("dbo.Books", "Author");
            DropColumn("dbo.Books", "ProductionDate");
        }
    }
}
