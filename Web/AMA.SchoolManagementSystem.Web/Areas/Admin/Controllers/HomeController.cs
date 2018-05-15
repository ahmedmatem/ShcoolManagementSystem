namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: Admin/home
        public ActionResult Index()
        {
            return View();
        }
    }
}