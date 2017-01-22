namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heh1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthorBooks", newName: "BookAuthors");
            DropForeignKey("dbo.Addresses", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", new[] { "Book_BookID", "Author_AuthorID" });
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.AddressID);
            
            DropPrimaryKey("dbo.BookAuthors");
            AddPrimaryKey("dbo.BookAuthors", new[] { "Author_AuthorID", "Book_BookID" });
            CreateIndex("dbo.Addresses", "UserID");
            AddForeignKey("dbo.Addresses", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BookAuthors", newName: "AuthorBooks");
        }
    }
}
