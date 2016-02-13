namespace WatchMe.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryIdentifier { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}