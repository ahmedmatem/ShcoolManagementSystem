namespace AMA.SchoolManagementSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels;
    using AMA.SchoolManagementSystem.Web.Inrastructure;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Components;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;

    [Authorize(Roles = "SuperAdmin")]
    public class HomeController : BaseController
    {
        private readonly IEfRepository<School> schoolRepository;
        private readonly ISaveContext context;

        public HomeController(IEfRepository<School> schoolRepository, ISaveContext context)
        {
            this.schoolRepository = schoolRepository;
            this.context = context;
        }

        // GET: Admin/home
        public ActionResult Index()
        {
            var model = schoolRepository.All()
                                    .ProjectTo<SchoolViewModel>()
                                    .ToList();

            return View(model);
        }
    }
}