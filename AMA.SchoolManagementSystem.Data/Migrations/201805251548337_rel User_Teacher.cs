namespace AMA.SchoolManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relUser_Teacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schools", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Schools", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Schools", new[] { "Address_Id" });
            DropIndex("dbo.Schools", new[] { "Contact_Id" });
            DropColumn("dbo.Schools", "AddressId");
            DropColumn("dbo.Schools", "ContactId");
            RenameColumn(table: "dbo.Schools", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Schools", name: "Contact_Id", newName: "ContactId");
            AddColumn("dbo.Teachers", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Schools", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schools", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schools", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Schools", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "UserId");
            CreateIndex("dbo.Schools", "AddressId");
            CreateIndex("dbo.Schools", "ContactId");
            AddForeignKey("dbo.Teachers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Schools", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schools", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Schools", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Schools", new[] { "ContactId" });
            DropIndex("dbo.Schools", new[] { "AddressId" });
            DropIndex("dbo.Teachers", new[] { "UserId" });
            AlterColumn("dbo.Schools", "ContactId", c => c.Int());
            AlterColumn("dbo.Schools", "AddressId", c => c.Int());
            AlterColumn("dbo.Schools", "ContactId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Schools", "AddressId", c => c.Guid(nullable: false));
            DropColumn("dbo.Teachers", "UserId");
            RenameColumn(table: "dbo.Schools", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.Schools", name: "AddressId", newName: "Address_Id");
            AddColumn("dbo.Schools", "ContactId", c => c.Guid(nullable: false));
            AddColumn("dbo.Schools", "AddressId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Schools", "Contact_Id");
            CreateIndex("dbo.Schools", "Address_Id");
            AddForeignKey("dbo.Schools", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Schools", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
