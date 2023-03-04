using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubPresentersOpCodes
{
	//actually this is a client.
	public class MainParticip
	{
		HubPresenter hubPresenter = new HubPresenter();
		SessionCreatorView sessionCreatorView;

		public MainParticip()
		{
			sessionCreatorView = new SessionCreatorView(hubPresenter);
			hubPresenter.Register(sessionCreatorView);
		}

		public void cmdCreateSession()
		{
			hubPresenter.Publish(HubOp.CreateSession, "session 01-01-2022");
		}

		//где то должны ловить ответ.
	}
}
