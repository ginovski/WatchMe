namespace WatchMe.Services.Data
{
    using System;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class ActorsService : IActorsService
    {
        private IRepository<Actor> actors;

        public ActorsService(IRepository<Actor> actors)
        {
            this.actors = actors;
        }

        public IQueryable<Actor> ActorById(int id)
        {
            var actorQuery = this.actors.All().Where(a => a.Id == id);

            return actorQuery;
        }
    }
}
