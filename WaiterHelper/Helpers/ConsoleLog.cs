using System;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WaiterHelper.Helpers
{
    public class ConsoleLog : ILog
    {
        public void Exception(Exception ex) => Debug.WriteLine(ex.Message);

        public void Trace(string message) => Debug.WriteLine(message);

        public void Warning(string message) => Debug.WriteLine(message);


        public static void Output(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
