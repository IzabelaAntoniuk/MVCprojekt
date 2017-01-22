namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBase6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_BookID" });
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorID" });
            DropTable("dbo.BookAuthors");
        }
        
        public override void Down()
        {
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookID = c.Int(nullable: false),
                        Author_AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookID, t.Author_AuthorID });

            CreateIndex("dbo.BookAuthors", "Author_AuthorID");
            CreateIndex("dbo.BookAuthors", "Book_BookID");
            AddForeignKey("dbo.BookAuthors", "Author_AuthorID", "dbo.Authors", "AuthorID", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
