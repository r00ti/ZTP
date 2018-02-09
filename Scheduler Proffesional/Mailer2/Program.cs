using System;
using System.Configuration;
using System.Text;
using System.Threading;

namespace Mailer2
{
    class Program
    {
        public static void Main()
        {
            var reader = new BusReader(new Mailer());
            Console.Read();
        }
    }
}
