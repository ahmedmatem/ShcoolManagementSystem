namespace AMA.SchoolManagementSystem.Web.Controllers
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Services.Contracts;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;
    using AMA.SchoolManagementSystem.Web.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ISaveContext context;

        public HomeController(IPostsService postsService, ISaveContext context)
        {
            this.postsService = postsService;
            this.context = context;
        }

        public ActionResult Index()
        {
            var posts = postsService
                .GetAll()
                .ProjectTo<PostViewModel>()
                .ToList();

            return View(posts);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdatePost(PostViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var post = new Post()
        //        {
        //            Title = model.Title,
        //            Content = model.Content,
        //            CreatedOn = model.PostedOn
        //        };

        //        postsService.Update(post);
        //        context.Commit();
        //    }

        //    return RedirectToAction("Index");
        //}

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