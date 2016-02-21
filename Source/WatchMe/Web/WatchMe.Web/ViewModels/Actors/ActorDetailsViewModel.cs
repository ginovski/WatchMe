namespace WatchMe.Web.ViewModels.Actors
{
    using AutoMapper;
    using Data.Models;
    using Infastructure.Mapping;
    using Common;
    using System.Collections.Generic;
    using System.Linq;
    public class ActorDetailsViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImagePath { get; set; }

        public double Rating { get; set; }

        public IEnumerable<ActorMovieViewModel> Movies { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Actor, ActorDetailsViewModel>()
              .ForMember(a => a.ProfileImagePath, opt => opt.MapFrom(a => !string.IsNullOrEmpty(a.ProfileImage.Path) ? WebConstants.ActorsImagesPath + a.ProfileImage.Path : WebConstants.DefaultActorImage));

            configuration.CreateMap<Actor, ActorDetailsViewModel>()
                .ForMember(a => a.Rating, opt => opt.MapFrom(a => a.Ratings.Count() > 0 ? a.Ratings.Average(r => r.Value) : 0));
        }
    }
}