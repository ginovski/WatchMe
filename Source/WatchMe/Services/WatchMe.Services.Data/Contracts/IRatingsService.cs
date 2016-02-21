namespace WatchMe.Services.Data.Contracts
{
    using WatchMe.Services.Common;

    public interface IRatingsService : IService
    {
        double RateMovie(string id, int rateValue, string userId);
    }
}
