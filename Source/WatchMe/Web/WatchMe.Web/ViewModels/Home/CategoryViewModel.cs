namespace WatchMe.Web.ViewModels.Home
{
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string CategoryIdentifier { get; set; }
    }
}