using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i3Visuals.Utils
{
    public static class CommonFunctions
    {
        public static void ErrorLog(string ErrorPage, string ErrorMessage, string ErrorStackTrace)
        {
            // Code that runs on application startup
            string root = ConfigurationManager.AppSettings[@"ErrorLogRoot"];
            string subdir = ConfigurationManager.AppSettings[@"ErrorLogSubDir"];
            string fileName = subdir + String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, "ErrorLog.txt");

            // If directory does not exist, create it.
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            // Create a sub directory
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            // Create New Log file into the sub directory
            if (Directory.Exists(subdir))
            {
                if (!File.Exists(fileName))
                {
                    // Create a new file     
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("New file created on: {0}", DateTime.Now.ToString());
                        sw.WriteLine("---------------------------------------------");
                    }
                }
                else if (File.Exists(fileName))
                {
                    // Create a new file     
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine("Issue On: {0}", DateTime.UtcNow.ToString());
                        sw.WriteLine("Error Page: {0}", ErrorPage.ToString());
                        sw.WriteLine("Error Message: {0}", ErrorMessage.ToString());
                        sw.WriteLine("Error Message: {0}", ErrorStackTrace.ToString());
                    }
                }
            }
        }
    }
}
