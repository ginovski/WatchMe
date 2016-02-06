namespace WatchMe.Data.Models
{
    using System.Collections.Generic;

    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

        public int? ProfileImageId { get; set; }

        public virtual Image ProfileImage { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}