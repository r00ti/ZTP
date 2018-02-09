using System;
using Topshelf;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;
using RabbitMQ.Client;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Tworzenie usługi TopShelf */
            HostFactory.Run(x =>
            {
                x.SetServiceName("CSVtoMail");
                x.SetDisplayName("CSVtoMail");
                x.SetDescription("This is sample service powered by TopShelf.");
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
