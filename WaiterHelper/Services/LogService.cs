using System;
using WaiterHelper.Helpers;
namespace WaiterHelper.Services
{
    public class LogService : ILog
    {
        void ILog.Exception(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        void ILog.Trace(string message)
        {
            Console.WriteLine(message);
        }

        void ILog.Warning(string message)
        {
            Console.WriteLine(message);
        }
    }
}
