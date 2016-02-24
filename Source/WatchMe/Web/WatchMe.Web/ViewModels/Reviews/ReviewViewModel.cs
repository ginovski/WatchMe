namespace WatchMe.Web.ViewModels.Reviews
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infastructure.Mapping;

    public class ReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Email { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewViewModel>()
                .ForMember(r => r.Email, opt => opt.MapFrom(r => r.User.Email));
        }
    }
}