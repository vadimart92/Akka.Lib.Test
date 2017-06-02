using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Akka.Actor;
using Terrasoft.Core;

namespace Terrasoft.WebAppActorSystem
{

	public interface IActorsInitializer
	{

		IEnumerable<KeyValuePair<string, IActorRef>> InitActors(ActorSystem actorSystem);

	}

	public class WebAppActorSystem
	{

		public static WebAppActorSystem Instance { get; } = new WebAppActorSystem();

		private static readonly ConcurrentDictionary<string, IActorRef> _topActors = new ConcurrentDictionary<string, IActorRef>();

		private ActorSystem _actorSystem;
		private WebAppActorSystem() {
			
		} 

		public void Start() {
			_actorSystem = ActorSystem.Create("system");
			var actorsInitializers = ClassFactory.GetAll<IActorsInitializer>();
			foreach (IActorsInitializer initializer in actorsInitializers) {
				var actors = initializer.InitActors(_actorSystem);
				foreach (var actorInfo in actors) {
					if (!_topActors.TryAdd(actorInfo.Key, actorInfo.Value)) {
						throw  new Exception("Actor exists");
					}
				}
			}
		}

		public void Stop() {
			_actorSystem.Terminate();
		}

		public IActorRef FindActor(string name) {
			IActorRef result;
			_topActors.TryGetValue(name, out result);
			return result;
		}
	}
}
