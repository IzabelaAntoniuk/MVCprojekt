namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        street = c.String(),
                        code = c.String(),
                        country = c.String(),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Lends",
                c => new
                    {
                        LendID = c.Int(nullable: false, identity: true),
                        lendDate = c.DateTime(nullable: false),
                        returnDate = c.DateTime(nullable: false),
                        BookID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LendID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.BookID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        premiereDate = c.DateTime(nullable: false),
                        PublisherID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        description = c.String(),
                        state = c.String(),
                        ISBN = c.Int(nullable: false),
                        LendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        BookID = c.Int(nullable: false),
                        birthDate = c.DateTime(nullable: false),
                        deathDate = c.DateTime(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        website = c.String(),
                        description = c.String(),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_AuthorID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorID, t.Book_BookID })
                .ForeignKey("dbo.Authors", t => t.Author_AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Author_AuthorID)
                .Index(t => t.Book_BookID);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_CategoryID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryID, t.Book_BookID })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Book_BookID);
            
            CreateTable(
                "dbo.PublisherBooks",
                c => new
                    {
                        Publisher_PublisherID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherID, t.Book_BookID })
                .ForeignKey("dbo.Publishers", t => t.Publisher_PublisherID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherID)
                .Index(t => t.Book_BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lends", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PublisherBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.PublisherBooks", "Publisher_PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Lends", "BookID", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AuthorBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.PublisherBooks", new[] { "Book_BookID" });
            DropIndex("dbo.PublisherBooks", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.CategoryBooks", new[] { "Book_BookID" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_CategoryID" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_BookID" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_AuthorID" });
            DropIndex("dbo.Lends", new[] { "UserID" });
            DropIndex("dbo.Lends", new[] { "BookID" });
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropTable("dbo.PublisherBooks");
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Publishers");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Lends");
            DropTable("dbo.Addresses");
        }
    }
}
