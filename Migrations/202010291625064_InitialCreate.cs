namespace Bookshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        IdBook = c.Int(nullable: false, identity: true),
                        Tittle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdBook);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
