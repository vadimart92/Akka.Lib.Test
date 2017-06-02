using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;

namespace Terrasoft.Core.Process
{

	public class StartProcessActor : ReceiveActor
	{ }

	public class ProcessEngineActor: ReceiveActor
	{

		private readonly IActorRef _startProcessActors;
		public ProcessEngineActor() {
			_startProcessActors = Context.ActorOf(Props.Create<StartProcessActor>().WithRouter(FromConfig.Instance));
			Become(Ready);
		}

		private void Ready() {
			Receive<StartProcessMessage>(m => {
				_startProcessActors.Tell(m);
			});
		}

	}
}
