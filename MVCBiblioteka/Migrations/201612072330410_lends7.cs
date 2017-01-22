namespace MVCBiblioteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lends7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lends", "BookID", "dbo.Books");
            DropForeignKey("dbo.Lends", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", "dbo.ShoppingCartViewModels");
            DropIndex("dbo.Lends", new[] { "BookID" });
            DropIndex("dbo.Lends", new[] { "UserID" });
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_ShoppingCartViewModelID" });
            DropPrimaryKey("dbo.BooksCarts");
            CreateTable(
                "dbo.BooksCartRemoveViewModels",
                c => new
                    {
                        BooksCartRemoveViewModelID = c.String(nullable: false, maxLength: 128),
                        Message = c.String(),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CartCount = c.Int(nullable: false),
                        ItemCount = c.Int(nullable: false),
                        DeleteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BooksCartRemoveViewModelID);
            
            CreateTable(
                "dbo.BooksCartViewModels",
                c => new
                    {
                        BooksCartViewModelID = c.String(nullable: false, maxLength: 128),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BooksCartViewModelID);
            
            AddColumn("dbo.Carts", "BooksCartViewModel_BooksCartViewModelID", c => c.String(maxLength: 128));
            AddColumn("dbo.BooksCarts", "BooksCartID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.BooksCarts", "BooksCartID");
            CreateIndex("dbo.Carts", "BooksCartViewModel_BooksCartViewModelID");
            AddForeignKey("dbo.Carts", "BooksCartViewModel_BooksCartViewModelID", "dbo.BooksCartViewModels", "BooksCartViewModelID");
            DropColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID");
            DropColumn("dbo.BooksCarts", "ShoppingCartID");
            DropTable("dbo.Lends");
            DropTable("dbo.ShoppingCartRemoveViewModels");
            DropTable("dbo.ShoppingCartViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        ShoppingCartViewModelID = c.String(nullable: false, maxLength: 128),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartViewModelID);
            
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
                "dbo.Lends",
                c => new
                    {
                        LendID = c.Int(nullable: false, identity: true),
                        lendDate = c.DateTime(nullable: false),
                        returnDate = c.DateTime(nullable: false),
                        BookID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LendID);
            
            AddColumn("dbo.BooksCarts", "ShoppingCartID", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Carts", "BooksCartViewModel_BooksCartViewModelID", "dbo.BooksCartViewModels");
            DropIndex("dbo.Carts", new[] { "BooksCartViewModel_BooksCartViewModelID" });
            DropPrimaryKey("dbo.BooksCarts");
            DropColumn("dbo.BooksCarts", "BooksCartID");
            DropColumn("dbo.Carts", "BooksCartViewModel_BooksCartViewModelID");
            DropTable("dbo.BooksCartViewModels");
            DropTable("dbo.BooksCartRemoveViewModels");
            AddPrimaryKey("dbo.BooksCarts", "ShoppingCartID");
            CreateIndex("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID");
            CreateIndex("dbo.Lends", "UserID");
            CreateIndex("dbo.Lends", "BookID");
            AddForeignKey("dbo.Carts", "ShoppingCartViewModel_ShoppingCartViewModelID", "dbo.ShoppingCartViewModels", "ShoppingCartViewModelID");
            AddForeignKey("dbo.Lends", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Lends", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
