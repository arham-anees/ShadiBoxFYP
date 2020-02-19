namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cBookings",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tBookingResponses", t => t.BookingResponseId)
                .ForeignKey("dbo.cFunctionTimes", t => t.FunctionTimeId)
                .ForeignKey("dbo.tServiceProvider", t => t.ServiceProviderId)
                .ForeignKey("dbo.tUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ServiceProviderId)
                .Index(t => t.FunctionTimeId)
                .Index(t => t.BookingResponseId);
            
            CreateTable(
                "dbo.tBookingResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingRequestId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cBookingRequests", t => t.BookingRequestId)
                .Index(t => t.BookingRequestId);
            
            CreateTable(
                "dbo.cBookingRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ServiceProviderId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        NumberOfGuests = c.Int(nullable: false),
                        FunctionTimeId = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cFunctionTimes", t => t.FunctionTimeId)
                .ForeignKey("dbo.tServiceProvider", t => t.ServiceProviderId)
                .ForeignKey("dbo.tUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ServiceProviderId)
                .Index(t => t.FunctionTimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cBookings", "UserId", "dbo.tUser");
            DropForeignKey("dbo.cBookings", "ServiceProviderId", "dbo.tServiceProvider");
            DropForeignKey("dbo.cBookings", "FunctionTimeId", "dbo.cFunctionTimes");
            DropForeignKey("dbo.cBookings", "BookingResponseId", "dbo.tBookingResponses");
            DropForeignKey("dbo.tBookingResponses", "BookingRequestId", "dbo.cBookingRequests");
            DropForeignKey("dbo.cBookingRequests", "UserId", "dbo.tUser");
            DropForeignKey("dbo.cBookingRequests", "ServiceProviderId", "dbo.tServiceProvider");
            DropForeignKey("dbo.cBookingRequests", "FunctionTimeId", "dbo.cFunctionTimes");
            DropIndex("dbo.cBookingRequests", new[] { "FunctionTimeId" });
            DropIndex("dbo.cBookingRequests", new[] { "ServiceProviderId" });
            DropIndex("dbo.cBookingRequests", new[] { "UserId" });
            DropIndex("dbo.tBookingResponses", new[] { "BookingRequestId" });
            DropIndex("dbo.cBookings", new[] { "BookingResponseId" });
            DropIndex("dbo.cBookings", new[] { "FunctionTimeId" });
            DropIndex("dbo.cBookings", new[] { "ServiceProviderId" });
            DropIndex("dbo.cBookings", new[] { "UserId" });
            DropTable("dbo.cBookingRequests");
            DropTable("dbo.tBookingResponses");
            DropTable("dbo.cBookings");
        }
    }
}
