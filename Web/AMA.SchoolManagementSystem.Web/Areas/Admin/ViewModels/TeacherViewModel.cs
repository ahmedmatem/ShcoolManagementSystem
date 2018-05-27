namespace AMA.SchoolManagementSystem.Web.Areas.Admin.ViewModels
{
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class TeacherViewModel : IMapTo<Teacher>, IMapFrom<Teacher>
    {
        [Required]
        [StringLength(30, ErrorMessage = "Името трябва да съдържа от 2 до 30 символа", MinimumLength = 2)]
        [RegularExpression("^([a-zA-Zа-яА-Я ]+)$", ErrorMessage = "Името трябва да съдържа само букви")]
        [DisplayName("Име")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Името трябва да съдържа от 2 до 30 символа", MinimumLength = 2)]
        [RegularExpression("^([a-zA-Zа-яА-Я ]+)$", ErrorMessage = "Името трябва да съдържа само букви")]
        [DisplayName("Презиме")]
        public string FatherName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Името трябва да съдържа от 2 до 30 символа", MinimumLength = 2)]
        [RegularExpression("^([a-zA-Zа-яА-Я ]+)$", ErrorMessage = "Името трябва да съдържа само букви")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Име, презиме и фамилия")]
        public string Name => String.Format("{0} {1} {2}", FirstName, FatherName, LastName);
    }
}