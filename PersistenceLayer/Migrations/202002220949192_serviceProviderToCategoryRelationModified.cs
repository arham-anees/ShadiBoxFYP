namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceProviderToCategoryRelationModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceCategory_Id", "dbo.tServiceCategories");
            DropForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceProvider_Id", "dbo.tServiceProviders");
            DropIndex("dbo.cServiceCategorycServiceProviders", new[] { "cServiceCategory_Id" });
            DropIndex("dbo.cServiceCategorycServiceProviders", new[] { "cServiceProvider_Id" });
            AddColumn("dbo.tServiceProviders", "ServiceCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tServiceProviders", "cServiceCategory_Id", c => c.Int());
            CreateIndex("dbo.tServiceProviders", "ServiceCategoryId");
            CreateIndex("dbo.tServiceProviders", "cServiceCategory_Id");
            AddForeignKey("dbo.tServiceProviders", "cServiceCategory_Id", "dbo.tServiceCategories", "Id");
            AddForeignKey("dbo.tServiceProviders", "ServiceCategoryId", "dbo.tServiceCategories", "Id");
            DropTable("dbo.cServiceCategorycServiceProviders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.cServiceCategorycServiceProviders",
                c => new
                    {
                        cServiceCategory_Id = c.Int(nullable: false),
                        cServiceProvider_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cServiceCategory_Id, t.cServiceProvider_Id });
            
            DropForeignKey("dbo.tServiceProviders", "ServiceCategoryId", "dbo.tServiceCategories");
            DropForeignKey("dbo.tServiceProviders", "cServiceCategory_Id", "dbo.tServiceCategories");
            DropIndex("dbo.tServiceProviders", new[] { "cServiceCategory_Id" });
            DropIndex("dbo.tServiceProviders", new[] { "ServiceCategoryId" });
            DropColumn("dbo.tServiceProviders", "cServiceCategory_Id");
            DropColumn("dbo.tServiceProviders", "ServiceCategoryId");
            CreateIndex("dbo.cServiceCategorycServiceProviders", "cServiceProvider_Id");
            CreateIndex("dbo.cServiceCategorycServiceProviders", "cServiceCategory_Id");
            AddForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceProvider_Id", "dbo.tServiceProviders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceCategory_Id", "dbo.tServiceCategories", "Id", cascadeDelete: true);
        }
    }
}
