namespace WatchMe.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Movie
    {
        public Movie()
        {
            this.Categories = new HashSet<Category>();
            this.Cast = new HashSet<Actor>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string IMDBLink { get; set; }

        public int CoverImageId { get; set; }

        public virtual Image CoverImage { get; set; }

        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Actor> Cast { get; set; }
    }
}
