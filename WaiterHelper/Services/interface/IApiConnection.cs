using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace WaiterHelper.Services
{
    public interface IApiConnection
    {
        Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> PostAsync<T>(string url, object data, CancellationToken cancellationToken = default(CancellationToken));
        Task PostAsync(string url, object data, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> PutAsync<T>(string requestUrl, object editModel, CancellationToken cancellationToken = default(CancellationToken));

        string CurrentAuthHeader { get; }
    }
}
