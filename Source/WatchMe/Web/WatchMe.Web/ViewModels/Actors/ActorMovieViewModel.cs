namespace WatchMe.Web.ViewModels.Actors
{
    using System;
    using AutoMapper;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;
    using Common;
    public class ActorMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, ActorMovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.CoverImage.Path) ? WebConstants.MoviesImagesPath + c.CoverImage.Path : ""));
        }
    }
}