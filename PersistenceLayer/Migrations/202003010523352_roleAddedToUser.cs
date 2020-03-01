namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tUsers", "RoleId", c => c.Int(nullable: false,defaultValue:1));
            CreateIndex("dbo.tUsers", "RoleId");
            AddForeignKey("dbo.tUsers", "RoleId", "dbo.tRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tUsers", "RoleId", "dbo.tRoles");
            DropIndex("dbo.tUsers", new[] { "RoleId" });
            DropColumn("dbo.tUsers", "RoleId");
        }
    }
}
