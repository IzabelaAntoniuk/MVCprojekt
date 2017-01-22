namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "allname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "allname");
        }
    }
}
