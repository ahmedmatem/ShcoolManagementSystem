namespace AMA.SchoolManagementSystem.Data.Migrations
{
    using AMA.SchoolManagementSystem.Data.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AMA.SchoolManagementSystem.Data.MsSqlDbContext>
    {

        const string AdministrationUserName = "ahmed@matem.com";

        const string AdministrationPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AMA.SchoolManagementSystem.Data.MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedPosts(context);
        }

        private void SeedPosts(Data.MsSqlDbContext context)
        {
            if (!context.Posts.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var post = new Post
                    {
                        Title = "How to find the port for MS SQL Server " + i + "?",
                        Content = "On my computer, running Windows 10 and with SQL Server 2012 Express installed, SQL Server Configuration Manager isn't listed in the Windows start menu but can be found in the Computer Management MMC snap-in under the Services and Applications group. The dynamic port is also not under the 'SQL native client configuration' item (which is version 11.0 for me) but under the SQL Server Network Configuration item (and on the IP Addresses tab of the TCP/IP protocol properties window, at the very bottom, in the setting TCP Dynamic Ports).",
                        CreatedOn = DateTime.Now,
                        Author = context.Users.First(x => x.Email == AdministrationUserName)
                    };

                    context.Posts.Add(post);
                }
            }
        }

        private void SeedAdmin(Data.MsSqlDbContext context)
        {

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministrationUserName, Email = AdministrationUserName, EmailConfirmed = true };
                userManager.Create(user, AdministrationPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
