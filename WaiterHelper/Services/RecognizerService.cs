using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using WaiterHelper.Models;

namespace WaiterHelper.Services
{
    public class RecognizerService : ApiClientBase, IRecognizerService
    {
        public RecognizerService(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public async Task<string> RecognizeHandWrittenText(byte[] array)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", Consts.SubscriptionKey);

                string requestParameters = "mode=Handwritten";

                string uri = Consts.UriBase + "?" + requestParameters;

                HttpResponseMessage response;

                using (ByteArrayContent content = new ByteArrayContent(array))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                    return response.Headers.GetValues("Operation-Location").FirstOrDefault();

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponceRecognizeModel> GetResult(string operationLocation)
        {
            return await ApiConnection.GetAsync<ResponceRecognizeModel>(operationLocation);
        }
    }
}
