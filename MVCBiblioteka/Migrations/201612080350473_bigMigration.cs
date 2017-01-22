namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 70));
        }
    }
}
