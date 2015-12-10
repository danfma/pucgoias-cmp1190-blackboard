using System;
using Akka.Actor;

namespace Blackboard.Shared
{
	[Serializable]
	public class CollaboratorUp
	{
		public readonly IActorRef Receiver;

		public CollaboratorUp(IActorRef receiver)
		{
			Receiver = receiver;
		}
	}
}