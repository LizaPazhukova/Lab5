namespace EFCodeFirst.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteConnectionBeetweenProviderAndCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProviderProductCategories", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.ProviderProductCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropIndex("dbo.ProviderProductCategories", new[] { "Provider_Id" });
            DropIndex("dbo.ProviderProductCategories", new[] { "ProductCategory_Id" });
            DropTable("dbo.ProviderProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProviderProductCategories",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.ProductCategory_Id });
            
            CreateIndex("dbo.ProviderProductCategories", "ProductCategory_Id");
            CreateIndex("dbo.ProviderProductCategories", "Provider_Id");
            AddForeignKey("dbo.ProviderProductCategories", "ProductCategory_Id", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProviderProductCategories", "Provider_Id", "dbo.Providers", "Id", cascadeDelete: true);
        }
    }
}
