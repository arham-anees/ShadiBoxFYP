namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cServiceCategorycServiceProviders",
                c => new
                    {
                        cServiceCategory_Id = c.Int(nullable: false),
                        cServiceProvider_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cServiceCategory_Id, t.cServiceProvider_Id })
                .ForeignKey("dbo.cServiceCategories", t => t.cServiceCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.tServiceProvider", t => t.cServiceProvider_Id, cascadeDelete: true)
                .Index(t => t.cServiceCategory_Id)
                .Index(t => t.cServiceProvider_Id);
            
            AddColumn("dbo.tServiceProvider", "cCity_Id", c => c.Int());
            AddColumn("dbo.tServiceProvider", "cServiceType_Id", c => c.Int());
            AddColumn("dbo.tUser", "cRole_Id", c => c.Int());
            CreateIndex("dbo.tServiceProvider", "RentTypeId");
            CreateIndex("dbo.tServiceProvider", "CityId");
            CreateIndex("dbo.tServiceProvider", "ServiceTypeId");
            CreateIndex("dbo.tServiceProvider", "UserAddedById");
            CreateIndex("dbo.tServiceProvider", "cCity_Id");
            CreateIndex("dbo.tServiceProvider", "cServiceType_Id");
            CreateIndex("dbo.tUser", "cRole_Id");
            CreateIndex("dbo.tReviews", "UserId");
            CreateIndex("dbo.tReviews", "ServiceProviderId");
            CreateIndex("dbo.cSectionContents", "ServiceProviderId");
            CreateIndex("dbo.cSectionContents", "ContentTypeId");
            AddForeignKey("dbo.tServiceProvider", "UserAddedById", "dbo.tUser", "Id");
            AddForeignKey("dbo.tServiceProvider", "cCity_Id", "dbo.cCities", "Id");
            AddForeignKey("dbo.tServiceProvider", "CityId", "dbo.cCities", "Id");
            AddForeignKey("dbo.tServiceProvider", "RentTypeId", "dbo.cRentTypes", "Id");
            AddForeignKey("dbo.tServiceProvider", "cServiceType_Id", "dbo.cServiceTypes", "Id");
            AddForeignKey("dbo.tServiceProvider", "ServiceTypeId", "dbo.cServiceTypes", "Id");
            AddForeignKey("dbo.tReviews", "ServiceProviderId", "dbo.tServiceProvider", "Id");
            AddForeignKey("dbo.tReviews", "UserId", "dbo.tUser", "Id");
            AddForeignKey("dbo.tUser", "cRole_Id", "dbo.cRoles", "Id");
            AddForeignKey("dbo.cSectionContents", "ContentTypeId", "dbo.cSectionContentTypes", "Id");
            AddForeignKey("dbo.cSectionContents", "ServiceProviderId", "dbo.tServiceProvider", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cSectionContents", "ServiceProviderId", "dbo.tServiceProvider");
            DropForeignKey("dbo.cSectionContents", "ContentTypeId", "dbo.cSectionContentTypes");
            DropForeignKey("dbo.tUser", "cRole_Id", "dbo.cRoles");
            DropForeignKey("dbo.tReviews", "UserId", "dbo.tUser");
            DropForeignKey("dbo.tReviews", "ServiceProviderId", "dbo.tServiceProvider");
            DropForeignKey("dbo.tServiceProvider", "ServiceTypeId", "dbo.cServiceTypes");
            DropForeignKey("dbo.tServiceProvider", "cServiceType_Id", "dbo.cServiceTypes");
            DropForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceProvider_Id", "dbo.tServiceProvider");
            DropForeignKey("dbo.cServiceCategorycServiceProviders", "cServiceCategory_Id", "dbo.cServiceCategories");
            DropForeignKey("dbo.tServiceProvider", "RentTypeId", "dbo.cRentTypes");
            DropForeignKey("dbo.tServiceProvider", "CityId", "dbo.cCities");
            DropForeignKey("dbo.tServiceProvider", "cCity_Id", "dbo.cCities");
            DropForeignKey("dbo.tServiceProvider", "UserAddedById", "dbo.tUser");
            DropIndex("dbo.cServiceCategorycServiceProviders", new[] { "cServiceProvider_Id" });
            DropIndex("dbo.cServiceCategorycServiceProviders", new[] { "cServiceCategory_Id" });
            DropIndex("dbo.cSectionContents", new[] { "ContentTypeId" });
            DropIndex("dbo.cSectionContents", new[] { "ServiceProviderId" });
            DropIndex("dbo.tReviews", new[] { "ServiceProviderId" });
            DropIndex("dbo.tReviews", new[] { "UserId" });
            DropIndex("dbo.tUser", new[] { "cRole_Id" });
            DropIndex("dbo.tServiceProvider", new[] { "cServiceType_Id" });
            DropIndex("dbo.tServiceProvider", new[] { "cCity_Id" });
            DropIndex("dbo.tServiceProvider", new[] { "UserAddedById" });
            DropIndex("dbo.tServiceProvider", new[] { "ServiceTypeId" });
            DropIndex("dbo.tServiceProvider", new[] { "CityId" });
            DropIndex("dbo.tServiceProvider", new[] { "RentTypeId" });
            DropColumn("dbo.tUser", "cRole_Id");
            DropColumn("dbo.tServiceProvider", "cServiceType_Id");
            DropColumn("dbo.tServiceProvider", "cCity_Id");
            DropTable("dbo.cServiceCategorycServiceProviders");
        }
    }
}
