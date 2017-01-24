namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heh3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isConfirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isConfirm");
        }
    }
}
