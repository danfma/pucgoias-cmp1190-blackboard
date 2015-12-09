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
      
      using (var system = ActorSystem.Create("blackboard", ConfigurationFactory.ParseString(fileContent))) {
        var registry = system.ActorOf(Props.Create<Registry>(), "registry");
        
        registry.Tell("Iniciado");
        Console.ReadLine();
      }
    }
  }

    public class Registry : TypedActor, IHandle<string>, IHandle<Ping>
    {
        public void Handle(Ping message)
        {
            Console.WriteLine("Recebi PING");
        }

        public void Handle(string message)
        {
            Console.WriteLine("Recebido: {0}:", message);
        }
    }
}