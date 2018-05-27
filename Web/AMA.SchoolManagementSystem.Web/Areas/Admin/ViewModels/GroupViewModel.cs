namespace AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class GroupViewModel
    {
        [Required]
        [DisplayName("Име")]
        public string Name { get; set; }
    }
}