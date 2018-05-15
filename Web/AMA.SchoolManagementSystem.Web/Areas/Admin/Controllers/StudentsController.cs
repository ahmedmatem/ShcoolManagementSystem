namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        // GET: Admin/Students
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.StudentsName)
            };

            return View();
        }

        // GET: Admin/Students/add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.StudentsName, Breadcrumb.AdminStudentsUrl),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View();
        }
    }
}