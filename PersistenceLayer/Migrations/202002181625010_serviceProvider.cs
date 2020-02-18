namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceProvider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tServiceProvider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        CoverPicture = c.String(),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        RentTypeId = c.Int(nullable: false),
                        Rent = c.Double(nullable: false),
                        CityId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        DateAddedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserAddedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tServiceProvider");
        }
    }
}
