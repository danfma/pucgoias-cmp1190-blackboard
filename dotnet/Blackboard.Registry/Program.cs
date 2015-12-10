using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;

namespace Blackboard.Registry
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var fileContent = File.ReadAllText("application.conf");

			using (var system = ActorSystem.Create("blackboard", ConfigurationFactory.ParseString(fileContent)))
			{
				system.ActorOf(Props.Create<RegistryActor>(), "registry");
				Console.ReadLine();
			}
		}
	}
}