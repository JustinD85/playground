﻿using static System.Console;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace threads
{
    class Program
    {
        static bool hacking = true;
        static void Main(string[] args)
        {
            WriteLine("Simulating Hacking the Internet... ");
            Hack(onComplete);
            WriteLine("Waiting for the Hack to Complete... ");

            while (hacking)
            { WriteLine("Waiting...:> "); ReadLine(); }
        }
        static void onComplete()
        {
            WriteLine("Hack Complete! Watch out for the Feds... ");
            hacking = false;
        }

        static void Hack(Action callback)
        {
            Task.Run(async () =>
           {
               // Thread.Sleep(3500);
               var client = new HttpClient();
               var data = await client.GetStringAsync("http://hack.com");
               WriteLine(data);
               callback();
           });
        }
    }
}
