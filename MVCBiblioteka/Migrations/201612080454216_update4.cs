namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserID", c => c.String());
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "UserID");
        }
    }
}
