namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "surname", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "deathDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "deathDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "surname", c => c.String());
            AlterColumn("dbo.Authors", "name", c => c.String());
        }
    }
}
