using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AMA.SchoolManagementSystem.Web.Startup))]
namespace AMA.SchoolManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
