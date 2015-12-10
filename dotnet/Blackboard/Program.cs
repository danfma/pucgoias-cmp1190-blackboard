using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using Blackboard.Forms;
using Blackboard.Shared;
using Eto.Forms;

namespace Blackboard
{
	public class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var fileContent = File.ReadAllText("application.conf");
			var config = ConfigurationFactory.ParseString(fileContent);

			using (var system = ActorSystem.Create("blackboard", config))
			{
				var bridge = system.ActorOf(Props.Create(() => new BlackboardBridgeActor()), "bridge");
				var registry = system.ActorSelection(config.GetString("blackboard.registry"));

				registry.Tell(new Ready(bridge));

				using (var app = new Application())
				{
					var form = new BlackboardForm();

					app.MainForm = form;

					form.Closed += (sender, _) => {
						registry.Ask(new CollaboratorDown(bridge), TimeSpan.FromSeconds(1));
					};

					form.Show();
					app.Run();
				}
			}
		}
	}
}