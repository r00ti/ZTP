using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Configuration;
using MassTransit.BusConfigurators;
using MassTransit.Log4NetIntegration.Logging;



namespace Scheduler
{
    public class BusControl
    {
        public static IServiceBus CreateBus(string queueName, Action<ServiceBusConfigurator> moreInitialization)
        {
            Log4NetLogger.Use();
            var bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom("rabbitmq://localhost/MtPubSubExample_" + queueName);
                moreInitialization(x);
            });

            return bus;
        }
    }
}
