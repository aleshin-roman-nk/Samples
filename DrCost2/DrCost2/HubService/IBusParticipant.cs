using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.HubService
{
	public interface IBusParticipant
	{
		string name { get; }
		// здесь обрабатывается сообщение через словарь методов
		// хотя методы можем так же помечать
		// при регистрации строится словарь в хабе

		// в простом варианте хаб просто в списке ищет контроллер и отправляет на него сообщение
		void PutMessage(ParticMessage msg);
	}
}
