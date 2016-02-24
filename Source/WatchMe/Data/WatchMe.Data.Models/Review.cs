namespace WatchMe.Data.Models
{
    using System;

    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool Flagged { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}