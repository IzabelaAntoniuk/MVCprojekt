namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "fatherCategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "fatherCategoryID");
            AddForeignKey("dbo.Categories", "fatherCategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "fatherCategoryID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "fatherCategoryID" });
            DropColumn("dbo.Categories", "fatherCategoryID");
        }
    }
}
