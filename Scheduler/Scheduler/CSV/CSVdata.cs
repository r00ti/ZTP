using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class DataRecord
    {
        //Should have properties which correspond to the Column Names in the file i.e.
        //CommonName,FormalName,TelephoneCode,CountryCode
        public String CommonName { get; set; }
        public String FormalName { get; set; }
        public String TelephoneCode { get; set; }
        public String CountryCode { get; set; }
    }
}
