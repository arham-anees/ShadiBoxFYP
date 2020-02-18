namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sectionContent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cSectionContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ServiceProviderId = c.Int(nullable: false),
                        ContentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cSectionContents");
        }
    }
}
