namespace WatchMe.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Services.Common;

    public interface ICategoriesService : IService
    {
        IQueryable<Category> AllCategories();

        void Delete(int id);

        Category GetById(int id);

        void Update(Category category);
    }
}
