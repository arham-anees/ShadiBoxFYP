namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipMistakesCorrection0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tServiceProvider", "cCity_Id", "dbo.cCities");
            DropForeignKey("dbo.tServiceProvider", "cServiceType_Id", "dbo.cServiceTypes");
            DropIndex("dbo.tServiceProvider", new[] { "cCity_Id" });
            DropIndex("dbo.tServiceProvider", new[] { "cServiceType_Id" });
            DropColumn("dbo.tServiceProvider", "cCity_Id");
            DropColumn("dbo.tServiceProvider", "cServiceType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tServiceProvider", "cServiceType_Id", c => c.Int());
            AddColumn("dbo.tServiceProvider", "cCity_Id", c => c.Int());
            CreateIndex("dbo.tServiceProvider", "cServiceType_Id");
            CreateIndex("dbo.tServiceProvider", "cCity_Id");
            AddForeignKey("dbo.tServiceProvider", "cServiceType_Id", "dbo.cServiceTypes", "Id");
            AddForeignKey("dbo.tServiceProvider", "cCity_Id", "dbo.cCities", "Id");
        }
    }
}
