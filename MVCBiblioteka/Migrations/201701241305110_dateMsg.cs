namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateMsg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "date");
        }
    }
}
