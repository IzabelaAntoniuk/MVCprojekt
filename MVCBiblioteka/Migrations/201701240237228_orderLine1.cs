namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderLine1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Books", "stockLevel", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Book_BookID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Book_BookID");
            AddForeignKey("dbo.AspNetUsers", "Book_BookID", "dbo.Books", "BookID");
            DropColumn("dbo.AspNetUsers", "stockLevel");
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "stockLevel", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "Book_BookID", "dbo.Books");
            DropIndex("dbo.AspNetUsers", new[] { "Book_BookID" });
            DropColumn("dbo.AspNetUsers", "Book_BookID");
            DropColumn("dbo.Books", "stockLevel");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
