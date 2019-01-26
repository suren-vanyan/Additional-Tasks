﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GetJsonData
{
    class Program
    {
        public static void Print(List<Company> companies)
        {
            Parallel.ForEach(companies, (company) =>
            {
                Console.WriteLine($"Company Name:{company.Name},Id:{company.Id}\n");
                
            });
        }
        public static async void Run(string url, CancellationToken cToken)
        {
           var result=  await Task.Run(() => Call.GetDataAsync(url, cToken));
            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(result);
            Print(companies);
        }

        static void Main(string[] args)
        {
            string url = "https://www.itjobs.am/api/v1.0/companies";
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task task = Task.Factory.StartNew(() => Run(url, token));
            
            try
            {
                task.Wait();
                Thread.Sleep(30);
                tokenSource.Cancel();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

           Console.ReadLine();
        }
    }
}
