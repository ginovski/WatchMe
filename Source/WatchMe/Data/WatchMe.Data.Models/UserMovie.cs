namespace WatchMe.Data.Models
{
    public class UserMovie
    {
        public int Id { get; set; }

        public MovieState State { get; set; }

        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
