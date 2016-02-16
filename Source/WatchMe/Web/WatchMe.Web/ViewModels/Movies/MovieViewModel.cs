namespace WatchMe.Web.ViewModels.Movies
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    public class MovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string DirectorFullName { get; set; }

        public int? Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Rating { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<MovieCastViewModel> Cast { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.DirectorFullName, opt => opt.MapFrom(m => m.Director.FirstName + " " + m.Director.LastName));

            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.Categories, opt => opt.MapFrom(m => m.Categories.Select(c => c.Name)));

            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.Rating, opt => opt.MapFrom(m => m.Rating.Value));

            configuration.CreateMap<Movie, MovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => WebConstants.MoviesImagesPath + c.CoverImage.Path));
        }
    }
}