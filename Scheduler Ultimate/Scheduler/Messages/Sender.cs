using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Messages
{
    public class Sender
    {
        public DataRecord DataModel { get; set; }

        public Sender(DataRecord _dataModel)
        {
            DataModel = _dataModel;
        }
    }
}
