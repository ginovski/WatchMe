namespace WatchMe.Web.Areas.Administration.ViewModels.Actors
{
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;

    public class ActorViewModel : IMapFrom<Actor>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}