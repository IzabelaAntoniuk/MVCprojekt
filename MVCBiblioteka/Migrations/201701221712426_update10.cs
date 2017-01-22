namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "BookStateID", "dbo.BookStates");
            DropIndex("dbo.Books", new[] { "BookStateID" });
            RenameColumn(table: "dbo.Books", name: "BookStateID", newName: "BookStateID");
            AlterColumn("dbo.Books", "BookStateID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "BookStateID");
            AddForeignKey("dbo.Books", "BookStateID", "dbo.BookStates", "BookStateID", cascadeDelete: true);
            DropColumn("dbo.Books", "state");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "state", c => c.String(nullable: false));
            DropForeignKey("dbo.Books", "BookStateID", "dbo.BookStates");
            DropIndex("dbo.Books", new[] { "BookStateID" });
            AlterColumn("dbo.Books", "BookStateID", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "BookStateID", newName: "BookStateID");
            CreateIndex("dbo.Books", "BookStateID");
            AddForeignKey("dbo.Books", "BookStateID", "dbo.BookStates", "BookStateID");
        }
    }
}
