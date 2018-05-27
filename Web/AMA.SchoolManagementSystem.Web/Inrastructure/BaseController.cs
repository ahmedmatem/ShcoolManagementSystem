namespace AMA.SchoolManagementSystem.Web.Inrastructure
{
    using AMA.SchoolManagementSystem.Data.Contracts;
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using AMA.SchoolManagementSystem.Data.Repositories;
    using AMA.SchoolManagementSystem.Web.App_Start;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected IMapper Mapper { get; }

        public BaseController()
        {
            Mapper = AutoMapperConfig.Configuration.CreateMapper();
        }
    }
}