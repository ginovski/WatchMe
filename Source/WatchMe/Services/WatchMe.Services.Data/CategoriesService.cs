namespace WatchMe.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> AllCategories()
        {
            return this.categories.All();
        }

        public void Delete(int id)
        {
            var category = this.categories.GetById(id);

            this.categories.Delete(category);
            this.categories.SaveChanges();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public void Update(Category category)
        {
            this.categories.Update(category);
            this.categories.SaveChanges();
        }
    }
}
