namespace WatchMe.Web.ViewModels.Categories
{
    using AutoMapper;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;

    public class CategoryMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string DirectorFullName { get; set; }

        public int? Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Rating { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, CategoryMovieViewModel>()
                .ForMember(m => m.DirectorFullName, opt => opt.MapFrom(m => m.Director.FirstName + " " + m.Director.LastName));

            configuration.CreateMap<Movie, CategoryMovieViewModel>()
                .ForMember(m => m.Categories, opt => opt.MapFrom(m => m.Categories.Select(c => c.Name).Take(3)));

            configuration.CreateMap<Movie, CategoryMovieViewModel>()
                .ForMember(m => m.Rating, opt => opt.MapFrom(m => m.Ratings.Count() > 0 ? m.Ratings.Average(r => r.Value) : 0));

            configuration.CreateMap<Movie, CategoryMovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => WebConstants.MoviesImagesPath + c.CoverImage.Path));
        }
    }
}