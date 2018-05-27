namespace AMA.SchoolManagementSystem.Web.Inrastructure.DataAnnotations
{
    using AMA.SchoolManagementSystem.Data;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class SchoolAccessFilter : ActionFilterAttribute
    {
        private readonly IEfRepository<School> schoolRepository;
        private string role;

        public SchoolAccessFilter(string Role)
        {
            this.schoolRepository = new EfRepository<School>(MsSqlDbContext.Create());
            this.role = Role;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole(this.role))
            {
                var userId = filterContext.HttpContext.User.Identity.GetUserId();
                var schoolId = (int)filterContext.ActionParameters["id"];
                var targetSchool = schoolRepository.GetById(schoolId);
                if (targetSchool.AdminId != userId)
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Error",
                    };
                }
            }
        }
    }
}