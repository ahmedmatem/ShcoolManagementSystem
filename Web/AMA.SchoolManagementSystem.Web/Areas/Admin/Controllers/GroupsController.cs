namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class GroupsController : Controller
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