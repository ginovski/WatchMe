namespace WatchMe.Services.Data.Contracts
{
    using Common;
    using System.Linq;
    using WatchMe.Data.Models;

    public interface IActorsService : IService
    {
        IQueryable<Actor> ActorById(int id);

        void Delete(int id);

        IQueryable<Actor> AllActors();

        Actor GetById(int id);

        void Update(Actor actor);
    }
}