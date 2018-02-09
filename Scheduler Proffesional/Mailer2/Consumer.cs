using System;
using System.Threading.Tasks;
using MassTransit;
using Serilog;
using Scheduler;


namespace Mailer2
{
    public class Consumer : IConsumer<DataRecord>
    {
        private Mailer _mailer { get; set; }

        public Consumer(Mailer mailer)
        {
            _mailer = mailer;
        }
        public async Task Consume(ConsumeContext<DataRecord> context)
        {
            Log.Information("{0} ,{1}, {2}, {3}", context.Message.CommonName, context.Message.CountryCode, context.Message.FormalName,
                        context.Message.TelephoneCode);
         await _mailer.SendEmail(context.Message);

        }
    }
}
