using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace i3Visuals
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            string root = @"C:\Temp\";
            string subdir = @"C:\Temp\Logs\";
            DateTime dateTime = DateTime.Now;
            //string fileName = @"C:\Temp\Logs\dateTime+ '' +ErrorLog.txt";
            string baseFileName = String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, "ErrorLog.txt");
            string fileName = subdir + String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, "ErrorLog.txt");
            //string fileName = subdir + baseFileName;

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
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer
            // or SQLServer, the event is not raised.
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }
    }
}