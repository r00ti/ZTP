using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Messages;
using Akka.Actor;

namespace Scheduler.Actors
{
    public class ActorSender : ReceiveActor
    {
        private Mailer _mailer;
        public ActorSender()
        {
            _mailer = new Mailer();
            Receive<Sender>(s => Handle(s));
        }

        private async Task Handle (Sender _messages)
        {
            Console.WriteLine($"Received messaegs. Mail {1}", DateTime.Now, _messages.DataModel.CommonName);
            await _mailer.SendEmail(_messages.DataModel);
        }
    }
}
