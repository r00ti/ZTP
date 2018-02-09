using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Serilog;


namespace Scheduler
{
    public class BusSender
    {
        private readonly IBusControl _bus;

        public BusSender()
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(xcz =>
            {
                var host = xcz.Host(new Uri(("rabbitmq://localhost")), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
            _bus.Start();
        }
        public void Sender(DataRecord desc)
        {
            _bus.Publish(desc);
        }
    }
}
