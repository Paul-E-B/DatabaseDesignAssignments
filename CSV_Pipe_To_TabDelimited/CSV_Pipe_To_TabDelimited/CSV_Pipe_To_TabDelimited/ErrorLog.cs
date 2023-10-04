using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Pipe_To_TabDelimited
{
    internal class ErrorLog
    {
        static List<string> errorLog = new List<string>();

        public static void LogError(string error, string fileName)
        {
            errorLog.Add(error + " in " + fileName);
        }


        public static List<string> ReturnErrorLog()
        {
            return errorLog;
        }



    }
}
