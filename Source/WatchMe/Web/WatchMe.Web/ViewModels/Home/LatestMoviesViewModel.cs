namespace WatchMe.Web.ViewModels.Home
{
    using AutoMapper;
    using Data.Models;
    using Infastructure.Mapping;
    using Common;
    using System.Linq;
    using System.Collections.Generic;

    public class LatestMoviesViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public List<string> Categories { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Movie, LatestMoviesViewModel>()
               .ForMember(c => c.ImagePath, opt => opt.MapFrom(c => WebConstants.MoviesImagesPath + c.CoverImage.Path));

            configuration.CreateMap<Movie, LatestMoviesViewModel>()
              .ForMember(c => c.Categories, opt => opt.MapFrom(c => c.Categories.Select(cat => cat.Name).Take(3).ToList()));
        }
    }
}