using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Configuration;
using FluentEmail;


namespace Scheduler
{
    public class Mailer
    {
        public async Task SendEmail(DataRecord model)
        {
            string address = ((SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp")).From;
            Log.Information("{0} ,{1}, {2}, {3}", model.CommonName, model.CountryCode, model.FormalName,
                              model.TelephoneCode);
            var email = Email
                .From(address)
                .To(model.CommonName, model.FormalName)
                .Subject("Hello World!")
                .Body(model.TelephoneCode);
            Email.DefaultSender = new SmtpSender();
          //  email.Send();
            await email.SendAsync();
        }
    }
}
