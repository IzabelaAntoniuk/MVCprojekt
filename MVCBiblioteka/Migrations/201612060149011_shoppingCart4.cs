namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartRemoveViewModels",
                c => new
                    {
                        ShoppingCartRemoveViewModelID = c.String(nullable: false, maxLength: 128),
                        Message = c.String(),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CartCount = c.Int(nullable: false),
                        ItemCount = c.Int(nullable: false),
                        DeleteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartRemoveViewModelID);
            
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        ShoppingCartViewModelID = c.String(nullable: false, maxLength: 128),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartViewModelID);
            
            AddColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID");
            AddForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", "dbo.ShoppingCartViewModels", "ShoppingCartViewModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", "dbo.ShoppingCartViewModels");
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_ShoppingCartViewModelID" });
            DropColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID");
            DropTable("dbo.ShoppingCartViewModels");
            DropTable("dbo.ShoppingCartRemoveViewModels");
        }
    }
}
