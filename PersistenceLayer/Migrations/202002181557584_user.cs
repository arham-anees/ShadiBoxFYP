namespace PersistenceLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 30,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Index2",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: Index, IsUnique: True }")
                                },
                            }),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "Index");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.tUser", "Index");
            DropTable("dbo.tUser",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Username",
                        new Dictionary<string, object>
                        {
                            { "Index2", "IndexAnnotation: { Name: Index, IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
