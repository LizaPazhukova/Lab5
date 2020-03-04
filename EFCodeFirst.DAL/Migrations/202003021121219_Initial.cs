namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProductCategories",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.ProductCategory_Id })
                .ForeignKey("dbo.Providers", t => t.Provider_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.Provider_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.Product_Id })
                .ForeignKey("dbo.Providers", t => t.Provider_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Provider_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.ProviderProductCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.ProviderProductCategories", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProviderProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_Id" });
            DropIndex("dbo.ProviderProductCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProviderProductCategories", new[] { "Provider_Id" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.ProviderProductCategories");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
