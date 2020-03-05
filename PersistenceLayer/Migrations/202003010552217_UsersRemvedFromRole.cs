namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersRemvedFromRole : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.tUsers", new[] { "RoleId" });
            //DropIndex("dbo.tUsers", new[] { "cRole_Id" });
            //DropColumn("dbo.tUsers", "cRole_Id");
            //RenameColumn(table: "dbo.tUsers", name: "cRole_Id", newName: "RoleId");
            //AlterColumn("dbo.tUsers", "RoleId", c => c.Int(nullable: false));
            //CreateIndex("dbo.tUsers", "RoleId");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.tUsers", new[] { "RoleId" });
            //AlterColumn("dbo.tUsers", "RoleId", c => c.Int());
            //RenameColumn(table: "dbo.tUsers", name: "RoleId", newName: "cRole_Id");
            //AddColumn("dbo.tUsers", "cRole_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.tUsers", "cRole_Id");
            //CreateIndex("dbo.tUsers", "RoleId");
        }
    }
}
