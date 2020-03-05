namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tBookings", "BookingResponseId", "dbo.tBookingResponses");
            DropForeignKey("dbo.tBookings", "FunctionTimeId", "dbo.tFunctionTimes");
            DropForeignKey("dbo.tBookings", "ServiceProviderId", "dbo.tServiceProviders");
            DropForeignKey("dbo.tBookings", "UserId", "dbo.tUsers");
            DropIndex("dbo.tBookings", new[] { "UserId" });
            DropIndex("dbo.tBookings", new[] { "ServiceProviderId" });
            DropIndex("dbo.tBookings", new[] { "FunctionTimeId" });
            DropIndex("dbo.tBookings", new[] { "BookingResponseId" });
            DropTable("dbo.tBookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ServiceProviderId = c.Int(nullable: false),
                        FunctionTimeId = c.Int(nullable: false),
                        BookingResponseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tBookings", "BookingResponseId");
            CreateIndex("dbo.tBookings", "FunctionTimeId");
            CreateIndex("dbo.tBookings", "ServiceProviderId");
            CreateIndex("dbo.tBookings", "UserId");
            AddForeignKey("dbo.tBookings", "UserId", "dbo.tUsers", "Id");
            AddForeignKey("dbo.tBookings", "ServiceProviderId", "dbo.tServiceProviders", "Id");
            AddForeignKey("dbo.tBookings", "FunctionTimeId", "dbo.tFunctionTimes", "Id");
            AddForeignKey("dbo.tBookings", "BookingResponseId", "dbo.tBookingResponses", "Id");
        }
    }
}
