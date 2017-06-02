using System;
using Terrasoft.Core;

namespace Terrasoft.WebApp
{
	class Program
	{
		static void Main(string[] args) {
			WebAppActorSystem.WebAppActorSystem.Instance.Start();
			var uc = new UserConnection();
			Guid processSchemaUId = Guid.NewGuid();
			uc.ProcessEngine.StartProcess(processSchemaUId);
			Console.ReadKey(true);
			WebAppActorSystem.WebAppActorSystem.Instance.Stop();
		}
	}
}
