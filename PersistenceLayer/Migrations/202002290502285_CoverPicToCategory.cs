namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoverPicToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tServiceCategories", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tServiceCategories", "Picture");
        }
    }
}
