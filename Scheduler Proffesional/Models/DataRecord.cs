using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class DataRecord
    {
        public readonly string CommonName;
        public readonly string FormalName;
        public readonly string TelephoneCode;
        public readonly string CountryCode;

        public DataRecord(string CommonName, string FormalName, string TelephoneCode, string CountryCode)
        {
            this.CommonName = CommonName;
            this.FormalName = FormalName;
            this.TelephoneCode = TelephoneCode;
            this.CountryCode = CountryCode;
        }
    }
}
