namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknownChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tSectionContents", "ContentTypeId", "dbo.tSectionContentTypes");
            AddForeignKey("dbo.tSectionContents", "ContentTypeId", "dbo.tSectionContentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tSectionContents", "ContentTypeId", "dbo.tSectionContentTypes");
            AddForeignKey("dbo.tSectionContents", "ContentTypeId", "dbo.tSectionContentTypes", "Id");
        }
    }
}
