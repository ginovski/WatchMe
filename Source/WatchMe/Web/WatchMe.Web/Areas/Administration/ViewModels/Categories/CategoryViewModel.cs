namespace WatchMe.Web.Areas.Administration.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using WatchMe.Data.Models;
    using WatchMe.Web.Infastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Category identifier")]
        public string CategoryIdentifier { get; set; }
    }
}