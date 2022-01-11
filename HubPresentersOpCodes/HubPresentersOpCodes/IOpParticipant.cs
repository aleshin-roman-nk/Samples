using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubPresentersOpCodes
{
	// По идее этот интерфейс может реализовывать любой модуль.
	//	не обязательно это презентер. Может быть и морда.
	public interface IOpParticipant
	{
		void PerformEventCode(HubOp code, object arg);
	}
}
