namespace WatchMe.Data.Tools.Adapters
{
    using System;
    using System.Net;

    public class WebClientAdapter : IWebClientAdapter
    {
        private WebClient webClient;

        public WebClientAdapter()
        {
            this.webClient = new WebClient();
        }

        public void Dispose()
        {
            webClient.Dispose();
        }

        public void DownloadFile(string address, string fileName)
        {
            webClient.DownloadFile(address, fileName);
        }
    }
}
