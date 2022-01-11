using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubPresentersOpCodes
{
	// Все операции, которые поддерживает данный узел - хаб

	public enum HubOp 
	{ 
		CreateObj, 
		SaveObj, 
		EditObj, 
		RunSessionCollector, 
		RunBufferBox,
		/// <summary>
		/// Запускает процесс создания сессии
		/// </summary>
		CreateSession,
		/// <summary>
		/// Запускает окно работы с задачей.
		/// </summary>
		StartEditTask,
		/// <summary>
		/// Ответ - сессия создана, параметр - ссылка на созданную сессию
		/// </summary>
		SessionCreated
	}

	/*
	 * >>> 29-12-2021 00:13
	 * Только два способа передачи кода события:
	 * По адресу.
	 * Разослать всем участникам.
	 * 
	 * Таблица HubOp - Receiver
	 * То есть кто получает этот код.
	 * 
	 */

	public class HubPresenter
	{
		List<IOpParticipant> opParticipants = new List<IOpParticipant>();

		public void Publish(HubOp code, object arg)
		{
			foreach (var item in opParticipants)
			{
				item.PerformEventCode(code, arg);
			}
		}

		public void Register(IOpParticipant p)
		{
			opParticipants.Add(p);
		}
	}
}
