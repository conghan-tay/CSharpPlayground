using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleApp_DerekBanas
{
    class ParallelTask
    {
        static void Main(string [] args)
        {
            // DownloadSynchronously();
            DownloadSynchronously_Temp2();
            Console.WriteLine("Waiting to finish on thread{0}...",
                Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }

        private static void DownloadSynchronously()
        {
            string[] urls =
            {
                "http://www.pluralsight-training.net/microsoft",
                "https://www.microsoft.com/en-sg",
                "http://twitter.com/odetocode"
            };

            foreach(string url in urls)
            {
                var client = new WebClient();
                var html = client.DownloadString(url);
                Console.WriteLine("Download {0} chars from {1} on thread {2}",
                    html.Length, url, Thread.CurrentThread.ManagedThreadId);
            }
        }

        private static void DownloadSynchronously_Temp2()
        {
            string[] urls =
            {
                "http://www.pluralsight-training.net/microsoft",
                "https://www.microsoft.com/en-sg",
                "http://twitter.com/odetocode"
            };

            foreach (string url in urls)
            {
                //var thread = new Thread(Download);
                //thread.Start(url);

                DownloadStringAsync(url);
            }
        }
        private static void DownloadStringAsync(string url)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += (sender, args) =>
            {
                var html = args.Result;
                Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, args.UserState as string, Thread.CurrentThread.ManagedThreadId);
            };
            client.DownloadStringAsync(new Uri(url), url);
        }
        private static void Download(object url)
        {
            var client = new WebClient();
            var html = client.DownloadString(url.ToString());
            Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, url, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
