using System;
using Akka.Actor;

namespace Terrasoft.Core.Process
{
	class ProcessEngineImpl: ProcessEngine
	{

		public override void StartProcess(Guid schemaUId) {
			Actors.ProcessEngineActor.Tell(new StartProcessMessage {
				SchemaUId = schemaUId
			}, ActorRefs.NoSender);
		}

	}
}
