using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindiwConvertation
{
	public interface IManView
	{
		void Go(Man m, Action<ViewResult> resultHandler);
	}
}
