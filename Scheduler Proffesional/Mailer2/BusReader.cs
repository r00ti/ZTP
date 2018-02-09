using System;
using System.Collections.Generic;
using System.Text;
using MassTransit;
using System.Configuration;

namespace Mailer2
{
    public class BusReader
    {
        private static readonly string _hostQueueKey = "serviceBusQueueName";
        private readonly IBusControl rabbitBusControl;
        private Mailer _mailer { get; set; }

        public BusReader(Mailer mail)
        {
            _mailer = mail;
            rabbitBusControl = Bus.Factory.CreateUsingRabbitMq(xcz =>
            {
                var config = ConfigurationManager.AppSettings;
                var host = xcz.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                xcz.ReceiveEndpoint(host, config.Get(_hostQueueKey), eks =>
                {
                    eks.Consumer(() => new Consumer(_mailer));
                });
            });
            rabbitBusControl.Start();
        }
    }
}
