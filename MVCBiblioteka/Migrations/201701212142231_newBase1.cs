namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBase1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryBooks", newName: "CategoryBooks1");
            RenameTable(name: "dbo.PublisherBooks", newName: "PublisherBooks1");
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        AuthorBooksID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorBooksID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        CategoryBooksID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryBooksID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.PublisherBooks",
                c => new
                    {
                        PublisherBooksID = c.Int(nullable: false, identity: true),
                        PublisherID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherBooksID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.PublisherID)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherBooks", "PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.PublisherBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "AuthorID", "dbo.Authors");
            DropIndex("dbo.PublisherBooks", new[] { "BookID" });
            DropIndex("dbo.PublisherBooks", new[] { "PublisherID" });
            DropIndex("dbo.CategoryBooks", new[] { "BookID" });
            DropIndex("dbo.CategoryBooks", new[] { "CategoryID" });
            DropIndex("dbo.AuthorBooks", new[] { "BookID" });
            DropIndex("dbo.AuthorBooks", new[] { "AuthorID" });
            DropTable("dbo.PublisherBooks");
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.AuthorBooks");
            RenameTable(name: "dbo.PublisherBooks1", newName: "PublisherBooks");
            RenameTable(name: "dbo.CategoryBooks1", newName: "CategoryBooks");
        }
    }
}
