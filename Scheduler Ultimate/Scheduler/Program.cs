using System;
using Topshelf;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;
using Akka.Actor;
using Scheduler.Actors;
using System.Configuration;




namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Tworzenie usługi TopShelf */
            HostFactory.Run(x =>
            {
                x.SetServiceName("Scheduler Ultimate");
                x.SetDisplayName("Scheduler Ultimate");
                x.SetDescription("Scheduler using Actor Model");
                x.StartAutomatically();
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.LiterateConsole()
                    .WriteTo.RollingFile("logs\\Scheduler-{Date}.txt")
                    .CreateLogger();
                x.Service<IService>(service =>
               {
                   service.ConstructUsing(srv => new IService());
                   service.WhenStarted(srv =>
                   {
                       srv.Start();
                   });
                   service.WhenStopped(srv =>
                   {
                       srv.Stop();
                   });
               });
                x.RunAsLocalSystem();
                x.StartManually();
            });
        }
    }
}
