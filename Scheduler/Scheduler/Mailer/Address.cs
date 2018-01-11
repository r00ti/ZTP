using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Address
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public Address()
        {
        }

        public Address(string emailAddress, string name = null)
        {
            EmailAddress = emailAddress;
            Name = name;
        }
    }
}
