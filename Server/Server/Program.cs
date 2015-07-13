using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static void Main(string[] args)
        {
            var listener = new ModifiedHttpListener(new Uri("http://localhost:8080/"));
            listener.StartListen();

            Console.WriteLine("Listening...");
            Console.Read();

        }
    }
}