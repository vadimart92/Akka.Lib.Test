using Akka.Actor;

namespace Terrasoft.Core.Process
{

	internal static class Actors
	{

		public static void Init(IActorRef processEngineActor) {
			_processEngineActor = processEngineActor;
		}

		private static IActorRef _processEngineActor;

		public static IActorRef ProcessEngineActor {
			get { return _processEngineActor; }
		}

	}
}
