namespace WatchMe.Data.Models
{
    using System.Collections.Generic;

    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
            this.Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int? ProfileImageId { get; set; }

        public virtual Image ProfileImage { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}