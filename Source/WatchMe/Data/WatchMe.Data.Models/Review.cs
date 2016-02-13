namespace WatchMe.Data.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool Flagged { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
