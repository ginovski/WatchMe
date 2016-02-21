namespace WatchMe.Web.ViewModels.Users
{
    using System;
    using AutoMapper;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;
    using Common;
    public class UserMovieViewModel : IMapFrom<UserMovie>, IHaveCustomMappings
    {
        public Guid? MovieId { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public MovieState State { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<UserMovie, UserMovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.Movie.CoverImage.Path) ? WebConstants.MoviesImagesPath + c.Movie.CoverImage.Path : ""));

            configuration.CreateMap<UserMovie, UserMovieViewModel>()
              .ForMember(c => c.Title, opt => opt.MapFrom(c => c.Movie.Title));
        }
    }
}