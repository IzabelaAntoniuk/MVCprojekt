namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.OrderDetails", "lendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderDetails", "returnDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.OrderDetails", "UserID");
            AddForeignKey("dbo.OrderDetails", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.OrderDetails", new[] { "UserID" });
            DropColumn("dbo.OrderDetails", "returnDate");
            DropColumn("dbo.OrderDetails", "lendDate");
            DropColumn("dbo.OrderDetails", "UserID");
        }
    }
}
