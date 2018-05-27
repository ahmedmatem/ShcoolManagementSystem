namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels;
    using AMA.SchoolManagementSystem.Web.Inrastructure;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using AMA.SchoolManagementSystem.Web.Inrastructure.DataAnnotations;

    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SchoolController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        private readonly IEfRepository<School> schoolRepository;
        private readonly ISaveContext saveContext;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public SchoolController(
            IEfRepository<School> schoolRepository, 
            ISaveContext context)
        {
            this.schoolRepository = schoolRepository;
            this.saveContext = context;
        }
        
        // GET: Admin/School/Index/scoolId
        [SchoolAccessFilter(WebRoles.Admin)]
        public ActionResult Index(int id)
        {
            var school = schoolRepository.GetById(id);
            SchoolViewModel model = this.Mapper.Map<SchoolViewModel>(school);
            ViewBag.SchoolName = school.Name;

            return View(model);
        }

        // GET: Admin/School/Add
        [Authorize(Roles ="SuperAdmin")]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(Breadcrumb.SchoolName, Breadcrumb.AdminSchoolUrl),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View();
        }

        // POST: Admin/School/Add
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SchoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            School newSchool = this.Mapper.Map<School>(model);
            schoolRepository.Add(newSchool);
            this.saveContext.Commit();

            return RedirectToAction("Index", "Home", new { area = "Admin"});
        }


        // GET: Admin/School/AddAdmin/schoolId
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult AddAdmin(int id)
        {
            School school = schoolRepository.GetById(id);

            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(school.Name, Breadcrumb.AdminSchoolUrl + "/index/" + id),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View(new RegisterAdminViewModel() { SchoolId = id } );
        }

        // Post: Admin/School/AddAdmin
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAdmin(RegisterAdminViewModel model)
        {
            School school = schoolRepository.GetById(model.SchoolId);

            if (ModelState.IsValid)
            {
                if (!RoleManager.RoleExists(WebRoles.Admin))
                {
                    RoleManager.Create(new IdentityRole(WebRoles.Admin));
                }

                var user = new User() { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Add user in Admin role
                    UserManager.AddToRole(user.Id, WebRoles.Admin);

                    // Add user id to school
                    school.AdminId = user.Id;
                    schoolRepository.Update(school);
                    saveContext.Commit();

                    return RedirectToAction("Index/" + model.SchoolId, new { area = "Admin"});
                }
                AddErrors(result);
            }

            ViewBag.Breadcrumb = new List<Breadcrumb>()
            {
                new Breadcrumb(Breadcrumb.HomeName, Breadcrumb.AdminHomeUrl),
                new Breadcrumb(school.Name, Breadcrumb.AdminSchoolUrl + "/index/" + model.SchoolId),
                new Breadcrumb(Breadcrumb.ActionAdd)
            };

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}