namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookstate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookStates",
                c => new
                    {
                        BookStateID = c.Int(nullable: false, identity: true),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.BookStateID);
            
            AddColumn("dbo.Books", "BookState_BookStateID", c => c.Int());
            CreateIndex("dbo.Books", "BookState_BookStateID");
            AddForeignKey("dbo.Books", "BookState_BookStateID", "dbo.BookStates", "BookStateID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookState_BookStateID", "dbo.BookStates");
            DropIndex("dbo.Books", new[] { "BookState_BookStateID" });
            DropColumn("dbo.Books", "BookState_BookStateID");
            DropTable("dbo.BookStates");
        }
    }
}
