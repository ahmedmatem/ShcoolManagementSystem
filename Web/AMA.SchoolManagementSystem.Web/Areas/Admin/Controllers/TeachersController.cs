namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using AMA.SchoolManagementSystem.Web.App_Start;
    using AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels;
    using AMA.SchoolManagementSystem.Web.Inrastructure;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;

    [Authorize(Roles = "SuperAdmin,Admin")]
    public class TeachersController : BaseController
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

            var model = teachersService
                                .All()
                                .ProjectTo<TeacherViewModel>()
                                .ToList();

            return View(model);
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
            
            Teacher newTeacher = this.Mapper.Map<Teacher>(model);
            this.teachersService.Add(newTeacher);
            this.context.Commit();

            return RedirectToAction("index");
        }
    }
}