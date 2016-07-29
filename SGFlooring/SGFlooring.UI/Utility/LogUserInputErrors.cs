using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.Utility
{
    public static class LogUserInputErrors
    {
        public static void LogInputErrors(string errorMessage, string userInput)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.WriteLine($"Time: {DateTime.Now} | Error Message: {errorMessage} | Error Input: {userInput}");
            }
        }

    }
}
