namespace WorkflowMax.Connector
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IConnector
    {
        Task Delete(string url);

        Task<HttpResponseMessage> Get(string url);

        Task<HttpResponseMessage> Post(string url, HttpContent content);

        Task<HttpResponseMessage> Put(string url, HttpContent content);
    }

    public class Connector : IConnector
    {
        public Connector(string accountKey, string apiKey, string url)
        {
            this.Url = url;
            this.ApiKey = apiKey;
            this.AccountKey = accountKey;
        }

        private string AccountKey { get; }

        private string ApiKey { get; }

        private string GetAuthenticationParams => $"?apiKey={this.ApiKey}&accountKey={this.AccountKey}";

        private string Url { get; }

        public async Task Delete(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Url);
                await client.DeleteAsync(url);
            }
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Url);
                var response = await client.GetAsync(url + this.GetAuthenticationParams);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Post(string url, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Url);
                var response = await client.PostAsync(url + this.GetAuthenticationParams, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Put(string url, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Url);
                var response = await client.PutAsync(url + this.GetAuthenticationParams, content);
                return response;
            }
        }
    }
}