using ChatServerConsoleSimberSoft.Models;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerConsoleSimberSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://localhost:8080/";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine(string.Format("Сервер запущен {0}", url));
                Console.ReadLine();
            }
        }
    }
}
