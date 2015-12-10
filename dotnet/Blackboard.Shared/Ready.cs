using System;
using Akka.Actor;

namespace Blackboard.Shared
{
	[Serializable]
	public class Ready
	{
		public readonly IActorRef Receiver;

		public Ready(IActorRef receiver)
		{
			Receiver = receiver;
		}
	}
}