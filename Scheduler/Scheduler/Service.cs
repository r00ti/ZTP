using System;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;
using Quartz;
using Topshelf;
using Quartz.Impl;
using MassTransit.Hosting;
using MassTransit.Logging;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Quartz;
using Quartz.Impl;
using QuartzIntegration;
using RabbitMqTransport;
using Topshelf;

namespace Scheduler
{
    public class ScheduleMessageService :
     ServiceControl
    {
        readonly IConfigurationProvider _configurationProvider;
        readonly int _consumerLimit;
        readonly ILog _log = Logger.Get<ScheduleMessageService>();
        readonly string _queueName;
        readonly IScheduler _scheduler;
        IBusControl _bus;
        BusHandle _busHandle;

        public ScheduleMessageService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _queueName = configurationProvider.GetSetting("ControlQueueName");
            _consumerLimit = configurationProvider.GetSetting("ConsumerLimit", Math.Min(2, Environment.ProcessorCount));

            _scheduler = CreateScheduler();
        }

        public bool Start(HostControl hostControl)
        {
            try
            {
                Uri serviceBusUri = _configurationProvider.GetServiceBusUri();

                if (serviceBusUri.Scheme.Equals("rabbitmq", StringComparison.OrdinalIgnoreCase))
                {
                    _bus = Bus.Factory.CreateUsingRabbitMq(x =>
                    {
                        IRabbitMqHost host = x.Host(serviceBusUri, h => _configurationProvider.GetHostSettings(h));
                        x.UseJsonSerializer();

                        x.ReceiveEndpoint(host, _queueName, e =>
                        {
                            e.PrefetchCount = (ushort)_consumerLimit;

                            e.Consumer(() => new ScheduleMessageConsumer(_scheduler));
                            e.Consumer(() => new CancelScheduledMessageConsumer(_scheduler));
                        });
                    });
                }

                _busHandle = _bus.Start();

                _scheduler.JobFactory = new MassTransitJobFactory(_bus);

                _scheduler.Start();
            }
            catch (Exception)
            {
                _scheduler.Shutdown();
                throw;
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _scheduler.Standby();

            if (_busHandle != null)
                _busHandle.Stop();

            _scheduler.Shutdown();

            return true;
        }

        static IScheduler CreateScheduler()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            IScheduler scheduler = schedulerFactory.GetScheduler();

            return scheduler;
        }
    }
}

