using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrasoft.Core
{
	public static class ClassFactory
	{

		public static IEnumerable<TInstance> GetAll<TInstance>() {
			throw new NotImplementedException("implemented in core");
		}
		public static TInstance Get<TInstance>() {
			throw new NotImplementedException("implemented in core");
		}

	}
}
