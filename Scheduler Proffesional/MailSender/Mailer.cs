using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Configuration;


namespace MailSender
{
    public class Mailer
    {
        public static async Task Process()
        {
            string address = ((SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp")).From;
            Log.Information("{0} ,{1}, {2}, {3}", record.CommonName, record.CountryCode, record.FormalName,
                              record.TelephoneCode);
            var email = Email
                .From(address)
                .To(record.CommonName, record.FormalName)
                .Subject("Hello!")
                .Body(record.TelephoneCode);
            Email.DefaultSender = new SmtpSender();
            await email.SendAsync();
        }
    }
}
