using System.Collections.Generic;
using Akka.Actor;
using Terrasoft.WebAppActorSystem;

namespace Terrasoft.Core.Process
{
	public class ActorsInitializer : IActorsInitializer
	{

		public IEnumerable<KeyValuePair<string, IActorRef>> InitActors(ActorSystem actorSystem) {
			var processEngineActorName = "ProcessEngineActor";
			IActorRef processEngineActor = actorSystem.ActorOf<ProcessEngineActor>(processEngineActorName);
			Actors.Init(processEngineActor);
			return new List<KeyValuePair<string, IActorRef>> {
				new KeyValuePair<string, IActorRef>(processEngineActorName, processEngineActor)
			};
		}

	}
}