using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindiwConvertation
{
	public interface IMainView
	{
		event EventHandler<Man> StartEdit;
		void DisplayMen(IEnumerable<Man> men);
	}
}
