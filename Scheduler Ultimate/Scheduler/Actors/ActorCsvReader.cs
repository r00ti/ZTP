using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Scheduler.Messages;
using System.Configuration;
using System.IO;
using CsvHelper;
using Serilog;
using Akka.Util.Internal;
using Scheduler.Actors;


namespace Scheduler.Actors
{
    public class ActorCsvReader : ReceiveActor
    {
        private Parser _dataParser = new Parser();

        public ActorCsvReader()
        {
            Receive<Reader>(x => Handle(x));
        }

        private void Handle(Reader message)
        {
            Console.WriteLine("Received messages with count {1}", DateTime.Now, message.CountMessages);
            var models = _dataParser.ParseCsv(message.CountMessages).ToList();
            models.ForEach(x => SendMessages(Context.ActorOf<ActorSender>(), x));
        }

        private void SendMessages(IActorRef actorRef, DataRecord x)
        {
            actorRef.Tell(new Sender(x));
        }
    }
}
