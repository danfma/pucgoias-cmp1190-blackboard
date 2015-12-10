using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using Blackboard.Shared;

namespace Blackboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileContent = File.ReadAllText("application.conf");

            using (var system = ActorSystem.Create("blackboard", ConfigurationFactory.ParseString(fileContent)))
            {
                var registry = system.ActorSelection("akka.tcp://blackboard@localhost:4000/user/registry");

                registry.Tell(new Ping());
                Console.ReadLine();
            }
        }
    }

    public class Bridge : TypedActor, IHandle<string>
    {
        public void Handle(string message)
        {
            Console.WriteLine("Recebido: {0}:", message);
        }
    }
}