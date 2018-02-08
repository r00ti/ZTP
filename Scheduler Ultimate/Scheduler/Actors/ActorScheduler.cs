using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Scheduler.Messages;

namespace Scheduler.Actors
{
    public class ActorScheduler : ReceiveActor
    {
        private ICancelable _cancelable;

        private int _count = 2;
        private int _timeSpan = 10;

        public ActorScheduler()
        {
            Receive<ScheduleMessage>(p => Handle(p));
        }

        public void Handle(ScheduleMessage message)
        {
            Console.WriteLine("Received schedule", DateTime.Now);
            var target = Context.ActorOf<ActorCsvReader>();
            target.Tell(new Reader(_count));
        }

        protected override void PreStart()
        {
            _cancelable = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(
                TimeSpan.Zero,
                TimeSpan.FromSeconds(_timeSpan),
                Self,
                new ScheduleMessage(),
                Self);
        }

        protected override void PostStop()
        {
            _cancelable.Cancel();
            Console.WriteLine("Scheduler canceled");
        }

    }
}
