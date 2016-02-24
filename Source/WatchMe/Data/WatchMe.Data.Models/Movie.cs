namespace WatchMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public Movie()
        {
            this.Id = Guid.NewGuid();
            this.Categories = new HashSet<Category>();
            this.Cast = new HashSet<Actor>();
            this.Users = new HashSet<UserMovie>();
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }

        [MaxLength(100)]
        [Index]
        public string Title { get; set; }

        public int? Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string IMDBLink { get; set; }

        public string Overview { get; set; }

        public int? CoverImageId { get; set; }

        public virtual Image CoverImage { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Actor> Cast { get; set; }

        public virtual ICollection<UserMovie> Users { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}