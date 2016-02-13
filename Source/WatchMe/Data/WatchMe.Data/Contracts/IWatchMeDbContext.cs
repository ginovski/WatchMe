namespace WatchMe.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IWatchMeDbContext
    {
        IDbSet<Actor> Actors { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Director> Directors { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<UserMovie> UserMovies { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
