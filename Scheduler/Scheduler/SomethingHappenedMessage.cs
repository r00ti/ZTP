using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class SomethingHappenedMessage : SomethingHappened
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }
}
