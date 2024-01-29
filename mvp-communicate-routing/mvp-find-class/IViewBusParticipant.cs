using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	public interface IViewBusParticipant
	{
		void PutMessage(ViewBusMessage msg);
		void hide();
		void rise();
		void oper();
	}
}
