namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heh2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "name", c => c.String());
            AddColumn("dbo.AspNetUsers", "surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "dateBirth", c => c.String());
            AddColumn("dbo.AspNetUsers", "phone", c => c.String());
            DropColumn("dbo.AspNetUsers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "phone");
            DropColumn("dbo.AspNetUsers", "dateBirth");
            DropColumn("dbo.AspNetUsers", "surname");
            DropColumn("dbo.AspNetUsers", "name");
        }
    }
}
