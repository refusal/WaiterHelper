using System;
using System.Threading.Tasks;
using WaiterHelper.Models;

namespace WaiterHelper.Services
{
    public interface IRecognizerService
    {
        Task<ResponceRecognizeModel> GetResult(string operationLocation);
        Task<string> RecognizeHandWrittenText(byte[] array);
    }
}
