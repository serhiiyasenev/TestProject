using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core
{
    public class HttpClientManager : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpClientManager(string authorizationUrl = null)
        {
            _httpClient = new HttpClient();
            AddServicePoint(authorizationUrl);
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => await _httpClient.SendAsync(request).ConfigureAwait(false);

        public void Dispose()
            => _httpClient?.Dispose();

        private void AddServicePoint(string endpoint = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (endpoint != null)
            {
                var eventHubServicePoint = ServicePointManager.FindServicePoint(new Uri(endpoint));
                eventHubServicePoint.ConnectionLeaseTimeout = 60 * 3 * 1000;
            }
        }

        public async Task<T> DeserializeObjectAsync<T>(HttpResponseMessage message)
        {
            var json = await message.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
        {
            var request = new HttpRequestMessage
            {
                Content    = content,
                RequestUri = new Uri(Urls.Base + endpoint),
                Method     = HttpMethod.Post
            };

            var response = await SendAsync(request);
            return response.EnsureSuccessStatusCode();
        }

        public static FormUrlEncodedContent CreateContent(string enteredValue)
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("number", $"{enteredValue}")
            });
        }
    }
}
