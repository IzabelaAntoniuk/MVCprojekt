namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booksChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "state", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "name", c => c.String());
            AlterColumn("dbo.Books", "state", c => c.String());
            AlterColumn("dbo.Books", "description", c => c.String());
            AlterColumn("dbo.Books", "title", c => c.String());
        }
    }
}
