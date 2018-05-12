namespace AMA.SchoolManagementSystem.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Web.Inrastructure.Mapping;
    using AutoMapper;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }
        
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy h:mm}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postVM => postVM.AuthorEmail, cfg => cfg.MapFrom(post => post.Author.Email))
                .ForMember(postVM => postVM.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn));
        }
    }
}