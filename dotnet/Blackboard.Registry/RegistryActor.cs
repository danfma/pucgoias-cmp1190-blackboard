using System;
using System.Collections.Generic;
using Akka.Actor;
using Blackboard.Shared;

namespace Blackboard.Registry
{
	public class RegistryActor : TypedActor,
		IHandle<Ready>
	{
		private readonly ISet<IActorRef> _blackboards = new HashSet<IActorRef>();
		private IActorRef _leader;

		private bool HasLeader => _leader != null;

		public void Handle(Ready message)
		{
			Console.WriteLine("Recebido registro de ator: {0}", message.Receiver.Path);

			var receiver = message.Receiver;

			_blackboards.Add(receiver);

			if (HasLeader)
			{
				Console.WriteLine("Avisando Lider sobre novo colaborador: {0}", message.Receiver.Path);
				_leader.Tell(new CollaboratorUp(receiver));
			}
			else
			{
				Console.WriteLine("Novo quadro e lider: {0}", message.Receiver.Path);

				_leader = receiver;
				receiver.Tell(new ActAsLeader());
			}
		}
	}
}