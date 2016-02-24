namespace WatchMe.Web.ViewModels.Movies
{
    using AutoMapper;
    using Common;
    using System.Collections.Generic;
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;

    public class DailyMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, DailyMovieViewModel>()
                .ForMember(m => m.Categories, opt => opt.MapFrom(m => m.Categories.Select(c => c.Name).Take(3)));

            configuration.CreateMap<Movie, DailyMovieViewModel>()
              .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => WebConstants.MoviesImagesPath + c.CoverImage.Path));
        }
    }
}