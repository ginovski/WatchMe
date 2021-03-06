﻿namespace WatchMe.Data
{
    using Common;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class WatchMeDbContext : IdentityDbContext<User>, IWatchMeDbContext
    {
        public WatchMeDbContext()
            : base(DataConstants.DefaultConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Director> Directors { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<UserMovie> UserMovies { get; set; }

        public static WatchMeDbContext Create()
        {
            return new WatchMeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Director>()
            //    .HasRequired(d => d.Rating)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Actor>()
            //    .HasRequired(d => d.Ratings)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Movie>()
            //    .HasRequired(d => d.Ratings)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Properties<Guid>()
           .Where(info => info.Name.ToLower() == "id")
           .Configure(configuration => configuration.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
        }
    }
}