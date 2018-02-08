using System;
using Serilog;
using Hangfire;
using Microsoft.Owin.Hosting;
using Akka.Actor;
using Scheduler.Actors;

namespace Scheduler
{
    public class IService
    {
        private ActorSystem _actorSystem;

        public void Start()
        {
            Log.Information("Start service...");
            string baseAddress = "http://localhost:9000/";
            //tworzenie aktora
            _actorSystem = ActorSystem.Create("Ultimate");

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                var scheduler = _actorSystem.ActorOf<ActorScheduler>();
                Console.WriteLine("Hangfire on");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public void Stop()
        {
            Log.Information("Stop service...");

            _actorSystem
                .Terminate()
                .ContinueWith(x => System.Console.WriteLine("Finish"));
        }
    }
}
