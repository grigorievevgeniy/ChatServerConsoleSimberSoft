using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace ChatServerConsoleSimberSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ConfigurationManager.AppSettings.Get("url");

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine(string.Format("Сервер запущен {0}", url));
                Console.ReadLine();
            }
        }
    }
}
