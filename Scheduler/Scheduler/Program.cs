using System;
using Topshelf;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;
using RabbitMQ.Client;

using System.Diagnostics;

using Topshelf.Logging;
using Topshelf.Runtime;
using MassTransit.Monitoring.Performance.Windows;

namespace Scheduler
{
    class Program
    {
        static int Main()
        {


            return (int)HostFactory.Run(x =>
            {
                x.AfterInstall(() =>
                {
                    VerifyEventLogSourceExists();

                    // this will force the performance counters to register during service installation
                    // making them created - of course using the InstallUtil stuff completely skips
                    // this part of the install :(
                    BusPerformanceCounters.Install();
                });

                x.Service(CreateService);
            });
        }

        static void VerifyEventLogSourceExists()
        {
            if (!EventLog.SourceExists("MassTransit"))
                EventLog.CreateEventSource("MassTransit Quartz Service", "MassTransit");
        }

        static ScheduleMessageService CreateService(HostSettings arg)
        {
            var configurationProvider = new FileConfigurationProvider();

            return new ScheduleMessageService(configurationProvider);
        }
    }
}
