namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookStates", "state", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookStates", "state", c => c.String());
        }
    }
}
