using System;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;


namespace Scheduler
{
    public class IService
    {
        public void Start()
        {
            Log.Information("Start service...");
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Minutely);

                RecurringJob.AddOrUpdate(() => Tasks.Process(), Cron.Minutely);
                Console.WriteLine("Hangfire on");
                Console.ReadKey();
             
        
            }
        }

        public void Stop()
        {
            Log.Information("Stop service...");
        }
    }
}
