using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubPresentersOpCodes
{
	public abstract class OpParticipantBase: IOpParticipant
	{
		protected HubPresenter _hub;

		public OpParticipantBase(HubPresenter hub)
		{
			_hub = hub;
		}

		abstract public void PerformEventCode(HubOp code, object arg);
	}
}
