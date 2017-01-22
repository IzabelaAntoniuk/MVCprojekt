namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booksChange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ISBN", c => c.Int(nullable: false));
        }
    }
}
