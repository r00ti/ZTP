using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Serilog;
using CsvHelper;
using System.IO;
using System.Net.Configuration;



namespace Scheduler
{
    public class Tasks
    {
        public static async Task Process()
        {
            string datafile = ConfigurationManager.AppSettings["DataFile"];
           string address = ((SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp")).From;

            using (var sr = new StreamReader(datafile))
            {
                var reader = new CsvReader(sr);
                IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();
                foreach (DataRecord record in records.Take(4))
                {
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
    }
}
