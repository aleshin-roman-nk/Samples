using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.HubService
{
	public class ParticipantsHub
	{
		Dictionary<string, IBusParticipant> _participants = new Dictionary<string, IBusParticipant>();

		public void Register(IBusParticipant participant)
		{
			if(_participants.ContainsKey(participant.name)) throw new InvalidOperationException($"participant {participant.name} already exists");
			_participants.Add(participant.name, participant);
		}

		public void Publish(ParticMessage msg)
		{
			if(!_participants.ContainsKey(msg.To))
				throw new InvalidOperationException($"participant {msg.To} does not exists in the table");

			_participants[msg.To].PutMessage(msg);
		}

		public void Publish(string from, string to, string method, object data)
		{
			Publish(new ParticMessage(from, to, method, data));
		}
	}
}
