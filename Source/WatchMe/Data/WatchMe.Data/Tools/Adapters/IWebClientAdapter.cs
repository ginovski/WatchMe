namespace WatchMe.Data.Tools.Adapters
{
    using System;

    public interface IWebClientAdapter : IDisposable
    {
        void DownloadFile(string address, string fileName);
    }
}