namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using AMA.SchoolManagementSystem.Web.App_Start;
    using AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly ITeachersService teachersService;
        private readonly ISaveContext context;
        private readonly IMapper mapper;

        public TeachersController(ITeachersService teachersService, ISaveContext context)
        {
            this.teachersService = teachersService;
            this.context = context;
            mapper = AutoMapperConfig.Configuration.CreateMapper();
        }

        // GET: Admin/Teachers
        public ActionResult Index()
        {

            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.TeachersName)
            };

            return View();
        }

        // GET: Admin/Teachers/Add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.TeachersName, Breadcrumb.AdminTeachersUrl),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View();
        }

        // POST: Admin/Teachers/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TeacherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Teacher newTeacher = mapper.Map<Teacher>(model);
            this.teachersService.Add(newTeacher);
            this.context.Commit();

            return RedirectToAction("index");
        }
    }
}