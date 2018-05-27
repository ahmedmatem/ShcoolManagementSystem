namespace AMA.SchoolManagementSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_in_school : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "AdminId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Schools", "AdminId");
            AddForeignKey("dbo.Schools", "AdminId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "AdminId", "dbo.AspNetUsers");
            DropIndex("dbo.Schools", new[] { "AdminId" });
            DropColumn("dbo.Schools", "AdminId");
        }
    }
}
