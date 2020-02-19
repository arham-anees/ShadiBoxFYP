namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipMistakesCorrection1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cProfileSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceProviderId = c.Int(nullable: false),
                        SectionHeadId = c.Int(nullable: false),
                        SectionContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cSectionContents", t => t.SectionContentId)
                .ForeignKey("dbo.cSectionHeads", t => t.SectionHeadId)
                .ForeignKey("dbo.tServiceProvider", t => t.ServiceProviderId)
                .Index(t => t.ServiceProviderId)
                .Index(t => t.SectionHeadId)
                .Index(t => t.SectionContentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cProfileSections", "ServiceProviderId", "dbo.tServiceProvider");
            DropForeignKey("dbo.cProfileSections", "SectionHeadId", "dbo.cSectionHeads");
            DropForeignKey("dbo.cProfileSections", "SectionContentId", "dbo.cSectionContents");
            DropIndex("dbo.cProfileSections", new[] { "SectionContentId" });
            DropIndex("dbo.cProfileSections", new[] { "SectionHeadId" });
            DropIndex("dbo.cProfileSections", new[] { "ServiceProviderId" });
            DropTable("dbo.cProfileSections");
        }
    }
}
