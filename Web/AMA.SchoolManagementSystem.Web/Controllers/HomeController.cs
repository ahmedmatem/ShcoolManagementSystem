namespace AMA.SchoolManagementSystem.Web.Controllers
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class HomeController : Controller
    {
        private readonly ISaveContext context;

        public HomeController(ISaveContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}