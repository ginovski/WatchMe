using System;
using AutoMapper;
using WatchMe.Data.Models;
using WatchMe.Web.Infastructure.Mapping;
using WatchMe.Web.Common;

namespace WatchMe.Web.ViewModels.Movies
{
    public class MovieCastViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Actor, MovieCastViewModel>()
              .ForMember(c => c.FullName, opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));

            configuration.CreateMap<Actor, MovieCastViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.ProfileImage.Path) ? WebConstants.ActorsImagesPath + c.ProfileImage.Path : ""));
        }
    }
}