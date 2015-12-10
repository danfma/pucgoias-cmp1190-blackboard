using System;
using System.Collections.Generic;
using Akka.Actor;
using Blackboard.Shared;

namespace Blackboard
{
	/// <summary>
	///     Ator responsável pelas comunicações externas.
	/// </summary>
	public class BlackboardBridgeActor : TypedActor,
		IHandle<ActAsLeader>,
		IHandle<KneelBeforeMe>,
		IHandle<CollaboratorUp>
	{
		/// <summary>
		///     Lista de quadros colaboradores sob a liderança desta instância.
		/// </summary>
		protected ISet<IActorRef> Collaborators = new HashSet<IActorRef>();

		/// <summary>
		///     Líder encontrado.
		/// </summary>
		protected IActorRef Leader { get; set; }

		/// <summary>
		///     Determina se há um líder já encontrado.
		/// </summary>
		protected bool HasLeader => Leader != null;

		/// <summary>
		///     Determina se esta instância é o líder.
		/// </summary>
		protected bool IsLeader { get; set; }

		public void Handle(ActAsLeader message)
		{
			IsLeader = true;

			Console.WriteLine("Ajoelhem-se diante de mim!!");
		}

		public void Handle(CollaboratorUp message)
		{
			Console.WriteLine("Mais um escravo pra mim!! Muahahaha");

			var collaborator = message.Receiver;

			Collaborators.Add(collaborator);
			collaborator.Tell(new KneelBeforeMe(Self));
		}

		public void Handle(KneelBeforeMe message)
		{
			Leader = message.Leader;

			Console.WriteLine("Eu ajoelho-me perante, {0}!!", Leader.Path);
		}
	}
}