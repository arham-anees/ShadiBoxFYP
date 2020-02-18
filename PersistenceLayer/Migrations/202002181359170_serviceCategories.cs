namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cServiceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.cServiceCategories", new[] { "Name" });
            DropTable("dbo.cServiceCategories");
        }
    }
}
