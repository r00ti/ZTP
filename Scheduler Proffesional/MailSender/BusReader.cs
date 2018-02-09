using System;
using System.Collections.Generic;
using System.Text;
using MassTransit;
using Scheduler;


namespace MailSender
{
    public class BusReader
    {
        private IBusControl _bus;
        private MailSender _email { get; set; }

        public BusReader(MailSender mail)
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(xcz =>
            {
                var host = xcz.Host(new Uri(("rabbitmq://localhost/")), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                xcz.ReceiveEndpoint(host, "mailer", eks => {
                eks.Consumer(() => new Consumer(_mailer));
                });
            });
            _bus.Start();
        }
     }
}
