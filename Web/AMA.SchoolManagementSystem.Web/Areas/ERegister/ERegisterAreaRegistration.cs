using System.Web.Mvc;

namespace AMA.SchoolManagementSystem.Web.Areas.ERegister
{
    public class ERegisterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ERegister";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ERegister_default",
                "ERegister/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}