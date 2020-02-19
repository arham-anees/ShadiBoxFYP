namespace PersistenceLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesRenaming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.cBookings", newName: "tBookings");
            RenameTable(name: "dbo.cBookingRequests", newName: "tBookingRequests");
            RenameTable(name: "dbo.cFunctionTimes", newName: "tFunctionTimes");
            RenameTable(name: "dbo.tServiceProvider", newName: "tServiceProviders");
            RenameTable(name: "dbo.tUser", newName: "tUsers");
            RenameTable(name: "dbo.cCities", newName: "tCities");
            RenameTable(name: "dbo.cRentTypes", newName: "tRentTypes");
            RenameTable(name: "dbo.cServiceCategories", newName: "tServiceCategories");
            RenameTable(name: "dbo.cServiceTypes", newName: "tServiceTypes");
            RenameTable(name: "dbo.cProfileSections", newName: "tProfileSections");
            RenameTable(name: "dbo.cSectionContents", newName: "tSectionContents");
            RenameTable(name: "dbo.cSectionContentTypes", newName: "tSectionContentTypes");
            RenameTable(name: "dbo.cSectionHeads", newName: "tSectionHeads");
            RenameTable(name: "dbo.cRoles", newName: "tRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tRoles", newName: "cRoles");
            RenameTable(name: "dbo.tSectionHeads", newName: "cSectionHeads");
            RenameTable(name: "dbo.tSectionContentTypes", newName: "cSectionContentTypes");
            RenameTable(name: "dbo.tSectionContents", newName: "cSectionContents");
            RenameTable(name: "dbo.tProfileSections", newName: "cProfileSections");
            RenameTable(name: "dbo.tServiceTypes", newName: "cServiceTypes");
            RenameTable(name: "dbo.tServiceCategories", newName: "cServiceCategories");
            RenameTable(name: "dbo.tRentTypes", newName: "cRentTypes");
            RenameTable(name: "dbo.tCities", newName: "cCities");
            RenameTable(name: "dbo.tUsers", newName: "tUser");
            RenameTable(name: "dbo.tServiceProviders", newName: "tServiceProvider");
            RenameTable(name: "dbo.tFunctionTimes", newName: "cFunctionTimes");
            RenameTable(name: "dbo.tBookingRequests", newName: "cBookingRequests");
            RenameTable(name: "dbo.tBookings", newName: "cBookings");
        }
    }
}
