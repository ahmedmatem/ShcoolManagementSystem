namespace AMA.SchoolManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        City = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressId = c.Guid(),
                        GroupId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        LastName = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.GroupId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressId = c.Guid(),
                        GroupId = c.Guid(),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        LastName = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Type = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressId = c.Guid(nullable: false),
                        ERegisterId = c.Guid(nullable: false),
                        Address = c.String(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ERegisters", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.ERegisters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SchoolId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "Id", "dbo.ERegisters");
            DropForeignKey("dbo.Groups", "Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "AddressId", "dbo.Addresses");
            DropIndex("dbo.ERegisters", new[] { "IsDeleted" });
            DropIndex("dbo.Schools", new[] { "IsDeleted" });
            DropIndex("dbo.Schools", new[] { "Id" });
            DropIndex("dbo.Teachers", new[] { "IsDeleted" });
            DropIndex("dbo.Teachers", new[] { "AddressId" });
            DropIndex("dbo.Students", new[] { "IsDeleted" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "AddressId" });
            DropIndex("dbo.Groups", new[] { "IsDeleted" });
            DropIndex("dbo.Groups", new[] { "Id" });
            DropIndex("dbo.Disciplines", new[] { "IsDeleted" });
            DropIndex("dbo.Addresses", new[] { "IsDeleted" });
            DropTable("dbo.ERegisters");
            DropTable("dbo.Schools");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Addresses");
        }
    }
}
