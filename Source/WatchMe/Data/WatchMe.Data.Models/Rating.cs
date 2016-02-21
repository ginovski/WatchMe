namespace WatchMe.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}