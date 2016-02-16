namespace WatchMe.Services.Web.Contracts
{
    using Common;
    using System;

    public interface ICacheService : IService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
