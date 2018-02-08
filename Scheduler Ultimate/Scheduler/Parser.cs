using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using Serilog;
using System.Threading.Tasks;
using System.Configuration;


namespace Scheduler
{
    public class Parser
    {
        string datafile = ConfigurationManager.AppSettings["DataFile"];
        public Parser()
        {
          //  datafile = _data;
        }
        public IEnumerable<DataRecord> ParseCsv(int _count)
        {
            IEnumerable<DataRecord> records;
            using (var sr = new StreamReader(@"D:\ZTP\Scheduler Ultimate\Scheduler\countrylist.csv"))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.Delimiter = ",";
                records = reader.GetRecords<DataRecord>();

                foreach (DataRecord record in records.Take(_count))
                {
                    Log.Information("{ 0} ,{1}, {2}, {3}", record.CommonName, record.CountryCode, record.FormalName,
                            record.TelephoneCode);
                }
            }
            return records.Take(_count);
        }
    }
}