namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShoppingCarts");
        }
    }
}
