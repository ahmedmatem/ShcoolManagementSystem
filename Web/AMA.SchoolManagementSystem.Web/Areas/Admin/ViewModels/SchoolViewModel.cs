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

    public class SchoolViewModel : IMapFrom<School>, IMapTo<School>, IHaveCustomMappings
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Училище")]
        public string Name { get; set; }

        // Address

        [Required]
        [DisplayName("Град")]
        public string City { get; set; }

        [Required]
        [DisplayName("Адресен ред 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Адресен ред 2")]
        public string AddressLine2 { get; set; }

        // Contact

        [Required]
        [DisplayName("Телефон 1")]
        public string Phone1 { get; set; }

        [DisplayName("Телефон 2")]
        public string Phone2 { get; set; }

        [Required]
        [DisplayName("Имейл")]
        public string Email { get; set; }

        // Administrator

        public User Admin { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<School, SchoolViewModel>()
                .ForMember(schoolVM => schoolVM.Name, cfg => cfg.MapFrom(school => school.Name))
                .ForMember(schoolVM => schoolVM.City, cfg => cfg.MapFrom(school => school.Address.City))
                .ForMember(schoolVM => schoolVM.AddressLine1, cfg => cfg.MapFrom(school => school.Address.AddressLine1))
                .ForMember(schoolVM => schoolVM.AddressLine2, cfg => cfg.MapFrom(school => school.Address.AddressLine2))
                .ForMember(schoolVM => schoolVM.Phone1, cfg => cfg.MapFrom(school => school.Contact.Phone1))
                .ForMember(schoolVM => schoolVM.Phone2, cfg => cfg.MapFrom(school => school.Contact.Phone2))
                .ForMember(schoolVM => schoolVM.Email, cfg => cfg.MapFrom(school => school.Contact.Email))
                .ReverseMap();
        }
    }
}