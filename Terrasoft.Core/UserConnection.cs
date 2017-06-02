using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrasoft.Core
{
	public class UserConnection
	{

		public ProcessEngine ProcessEngine {
			get { return ClassFactory.Get<ProcessEngine>(); }//ProcessEngineImpl
		}
	}
}
