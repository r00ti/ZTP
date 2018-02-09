using System;

namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var Reader = new BusReader(new MailSender);
        }
    }
}
