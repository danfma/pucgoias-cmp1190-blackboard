using System;
using Akka.Actor;

namespace Blackboard.Shared
{
	[Serializable]
	public class KneelBeforeMe
	{
		public readonly IActorRef Leader;

		public KneelBeforeMe(IActorRef leader)
		{
			Leader = leader;
		}
	}
}