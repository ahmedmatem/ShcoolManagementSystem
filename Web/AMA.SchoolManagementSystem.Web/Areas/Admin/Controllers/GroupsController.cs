namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AMA.SchoolManagementSystem.Web.Inrastructure;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;

    [Authorize(Roles = "SuperAdmin,Admin")]
    public class GroupsController : BaseController
    {
        // GET: Admin/Groups
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.GroupsName)
            };



            return View();
        }

        // GET: Admin/Groups/Add
        public ActionResult Add()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.GroupsName, Breadcrumb.AdminGroupsUrl),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View();
        }
    }
}