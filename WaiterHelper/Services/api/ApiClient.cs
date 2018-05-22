using System;
using Newtonsoft.Json;

namespace WaiterHelper.Services
{
    public class ApiClientBase
    {
        protected IApiConnection ApiConnection { get; set; }

        public ApiClientBase(IApiConnection apiConnection)
        {
            ApiConnection = apiConnection;
        }

        protected string AppendUrlParam(string path, string key, string value)
        {
            if (string.IsNullOrEmpty(value))
                return path;

            var appender = path.Contains("?") ? "&" : "?";
            return appender + key + "=" + value;
        }

        public string SerializeJson(object requestBody) => JsonConvert.SerializeObject(requestBody);

        public T DeserializeJsonTo<T>(string objectJson) => JsonConvert.DeserializeObject<T>(objectJson);
    }
}