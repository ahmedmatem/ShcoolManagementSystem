namespace AMA.SchoolManagementSystem.Services
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private ISaveContext saveContext;

        public UserService(ISaveContext saveContext)
        {
            this.saveContext = saveContext;
        }

        public void AddPrincipal(UserAuthModel userAuthModel)
        {
            var roleStore = new RoleStore<IdentityRole>(saveContext.Context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!roleManager.RoleExists("Principal"))
            {
                var role = new IdentityRole { Name = "Principal" };
                roleManager.Create(role);
            }

            var userStore = new UserStore<User>(saveContext.Context);
            var userManager = new UserManager<User>(userStore);
            var user = new User { UserName = userAuthModel.Email, Email = userAuthModel.Email, EmailConfirmed = true };
            userManager.Create(user, userAuthModel.Password);

            userManager.AddToRole(user.Id, "Principal");
        }
    }
}
