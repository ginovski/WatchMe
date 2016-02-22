namespace WatchMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string CategoryIdentifier { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}