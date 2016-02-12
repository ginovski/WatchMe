namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Services.Common;

    public interface ICategoriesService : IService
    {
        IQueryable<Category> AllCategories();
    }
}
