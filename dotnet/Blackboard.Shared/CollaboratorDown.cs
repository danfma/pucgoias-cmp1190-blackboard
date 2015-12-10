using System;
using Akka.Actor;

namespace Blackboard.Shared
{
	[Serializable]
	public class CollaboratorDown
	{
		public readonly IActorRef Receiver;

		public CollaboratorDown(IActorRef receiver)
		{
			Receiver = receiver;
		}
	}
}