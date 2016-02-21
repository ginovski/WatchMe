namespace WatchMe.Web.ViewModels.Actors
{
    using AutoMapper;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;
    using Common;

    public class ActorsListViewModel : IMapFrom<Actor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImagePath { get; set; }

        public int Rating { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Actor, ActorsListViewModel>()
              .ForMember(a => a.ProfileImagePath, opt => opt.MapFrom(a => !string.IsNullOrEmpty(a.ProfileImage.Path) ? WebConstants.ActorsImagesPath + a.ProfileImage.Path : WebConstants.DefaultActorImage));

            configuration.CreateMap<Actor, ActorsListViewModel>()
                .ForMember(a => a.Rating, opt => opt.MapFrom(a => a.Rating.Value));
        }
    }
}