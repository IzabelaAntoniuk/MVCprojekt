namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lends6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingCarts", newName: "BooksCarts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BooksCarts", newName: "ShoppingCarts");
        }
    }
}
