namespace WatchMe.Data.Models
{
    using System.Collections.Generic;

    public class Rating
    {
        public Rating()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}