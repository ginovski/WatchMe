namespace WatchMe.Web.ViewModels.Movies
{
    using AutoMapper;
    using Common;
    using Data.Models;
    using Infastructure.Mapping;
    using Reviews;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string DirectorFullName { get; set; }

        public int DirectorId { get; set; }

        public int? Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }

        public string ImagePath { get; set; }

        public string Overview { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<MovieCastViewModel> Cast { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        [IgnoreMap]
        public MovieState? State { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.DirectorFullName, opt => opt.MapFrom(m => m.Director.FirstName + " " + m.Director.LastName));

            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.Categories, opt => opt.MapFrom(m => m.Categories.Select(c => c.Name)));

            configuration.CreateMap<Movie, MovieViewModel>()
                .ForMember(m => m.Rating, opt => opt.MapFrom(m => m.Ratings.Count() > 0 ? m.Ratings.Average(r => r.Value) : 0));

            configuration.CreateMap<Movie, MovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => !string.IsNullOrEmpty(c.CoverImage.Path) ? WebConstants.MoviesImagesPath + c.CoverImage.Path : ""));

            configuration.CreateMap<Movie, MovieViewModel>()
              .ForMember(c => c.Reviews, opt => opt.MapFrom(c => c.Reviews.OrderByDescending(r => r.DateCreated)));
        }
    }
}