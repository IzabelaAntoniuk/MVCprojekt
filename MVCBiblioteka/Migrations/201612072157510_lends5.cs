namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lends5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
