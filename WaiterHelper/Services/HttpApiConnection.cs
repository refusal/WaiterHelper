using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WaiterHelper.Services
{
    public class HttpApiConnection : IApiConnection
    {
        private readonly HttpClient httpClient;

        public string CurrentAuthHeader { get; protected set; }

        public HttpApiConnection()
        {
            this.httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Consts.SubscriptionKey);
        }

        public async Task<T> PutAsync<T>(string requestUrl, object putData, CancellationToken cancellationToken)
        {
            var requestMessage = CreateRequest(requestUrl, HttpMethod.Put, SerializeObject(putData));
            var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            return await GetResponseContentAsync<T>(responseMessage);
        }

        public async Task<T> PostAsync<T>(string url, object postData, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = CreateRequest(url, HttpMethod.Post, SerializeObject(postData));
            var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            return await GetResponseContentAsync<T>(responseMessage);
        }

        public async Task PostAsync(string url, object postData, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = CreateRequest(url, HttpMethod.Post, SerializeObject(postData));
            var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
                ThrowIfUnsuccessfull(responseMessage, await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = CreateRequest(url, HttpMethod.Get);
            var response = await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response);
        }

        private async Task<T> GetResponseContentAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ThrowIfUnsuccessfull(response, content);
#if DEBUG
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception)
            {
                throw;
            }
#endif
#if RELEASE
            return JsonConvert.DeserializeObject<T>(content);
#endif
        }

        private HttpRequestMessage CreateRequest(string url, HttpMethod method, string postJson = null)
        {
            var requestMessage = new HttpRequestMessage(method, url);
            if (!string.IsNullOrWhiteSpace(postJson))
            {
                var httpContent = new StringContent(postJson, Encoding.UTF8, "application/json");
                requestMessage.Content = httpContent;
            }

            return requestMessage;
        }

        private string SerializeObject(object data) => JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

        private string GetAuthorizationHeaderValue(string token) => "Bearer " + token;

        private void ThrowIfUnsuccessfull(HttpResponseMessage response, string content)
        {
            if (response.IsSuccessStatusCode)
                return;

            if (response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception(response.StatusCode + Environment.NewLine + "Service is currently unavailable");
        }
    }
}