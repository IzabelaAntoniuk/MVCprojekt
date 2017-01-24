namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heh4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "stockLevel", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "stockLevel", c => c.Int(nullable: false));
        }
    }
}
