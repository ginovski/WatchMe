namespace WatchMe.Services.Data
{
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

        public IQueryable<Actor> AllActors()
        {
            return this.actors.All();
        }

        public void Delete(int id)
        {
            var actor = this.actors.GetById(id);

            this.actors.Delete(actor);
            this.actors.SaveChanges();
        }

        public Actor GetById(int id)
        {
            return this.actors.GetById(id);
        }

        public void Update(Actor actor)
        {
            this.actors.Update(actor);
            this.actors.SaveChanges();
        }
    }
}