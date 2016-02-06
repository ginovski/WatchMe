namespace WatchMe.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsSeen { get; set; }
    }
}