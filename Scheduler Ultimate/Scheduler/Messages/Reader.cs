using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using System.Configuration;
using System.IO;
using Serilog;
using CsvHelper;


namespace Scheduler.Messages
{
    public class Reader
    {
        public int CountMessages { get; set; }

        public Reader(int _countMessages)
        {
            CountMessages = _countMessages;
        }   
    }
}
