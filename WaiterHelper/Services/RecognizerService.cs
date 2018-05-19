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
            if (array?.Count() == 0)
                return null;

            string requestParameters = "?handwriting=true";
            string uri = Consts.UriBase + "?" + requestParameters;

            HttpResponseMessage response;

            using (ByteArrayContent content = new ByteArrayContent(array))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json"
                // and "multipart/form-data".
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                // The first REST call starts the async process to analyze the
                // written text in the image.
                response = await ApiConnection.PostAsync<HttpResponseMessage>(uri, content);
            }

            // The response contains the URI to retrieve the result of the process.
            if (response.IsSuccessStatusCode)
                return response.Headers.GetValues("Operation-Location").FirstOrDefault();
            else
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
