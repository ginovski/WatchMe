namespace WatchMe.Web.Areas.Administration.ViewModels.Reviews
{
    using AutoMapper;
    using Data.Models;
    using Infastructure.Mapping;

    public class ReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewViewModel>()
                .ForMember(r => r.AuthorUsername, opt => opt.MapFrom(r => r.User.UserName));
        }
    }
}