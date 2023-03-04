using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubPresentersOpCodes
{
	public class SessionCreatorView : OpParticipantBase
	{
		public SessionCreatorView(HubPresenter hub) : base(hub)
		{
		}

		public override void PerformEventCode(HubOp code, object arg)
		{
			// не должно быть зацикливания, так как вызов ответа _hub.Publish(HubOp.SessionCreated, "session of turkey"); только по событию code == HubOp.CreateSession
			if (code == HubOp.CreateSession)
			{
				Console.WriteLine($"session creation is started :{arg}");
				_hub.Publish(HubOp.SessionCreated, "session of turkey");// получаем зацикливание
				// надо делать двуканальное. запрос - один канал, ответ - другой канал.
			}
		}
	}
}
