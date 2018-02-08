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

                //CSVReader will now read the whole file into an enumerable
                IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();

                //First 5 records in CSV file will be printed to the Output Window
                foreach (DataRecord record in records.Take(3))
                {
                    Log.Information("{0} ,{1}, {2}, {3}", record.CommonName, record.CountryCode, record.FormalName,
                        record.TelephoneCode);
                    var email = Email
                        .From(address)
                        .To(record.CommonName, record.FormalName)
                        .Subject("Hello to ja program Adika")
                        .Body(record.TelephoneCode);

                    Email.DefaultSender = new SmtpSender();
                   await email.SendAsync();

                }

            }
        }
    }
}
