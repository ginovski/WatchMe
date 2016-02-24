namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Services.Common;

    public interface IReviewsService : IService
    {
        void Flag(int id);

        IQueryable<Review> GetAllFlagged();

        void Accept(int id);

        void Deny(int id);
    }
}