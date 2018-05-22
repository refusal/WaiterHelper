using System;
namespace WaiterHelper.Helpers
{
    public interface ILog
    {
        void Trace(string message);
        void Warning(string message);
        void Exception(Exception ex);
    }
}
