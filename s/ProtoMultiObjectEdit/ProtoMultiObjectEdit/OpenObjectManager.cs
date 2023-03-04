using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	/*
	 * Задача:
	 * Отправка объекта на открытие.
	 * Контроль сохранения изменений.
	 * 
	 */
	public class OpenObjectManager
	{
		List<IEntityInstanceWindow> _openObjects = new List<IEntityInstanceWindow> ();

		public OpenObjectManager()
		{
		}

		public event EventHandler<Obj> Save;
		public event EventHandler<int> OpenWindowsCountChanged;

		/*
		 * 
		 */
		public void Open(Obj o)
		{
			var op = _openObjects.FirstOrDefault(x => x.ObjId == o.id);

			if (op != null)
			{
				// It is not nessesary since we remove the view from the collection.
				// Thus _openObjects.FirstOrDefault is going to return null after a view is completed.
				//if (op.IsClosed)
				//{
				//	createView(o);
				//}
				//else
				op.Restore();
			}
			else
			{
				createView(o);
			}
		}

		/*
		 * [1]
		 * здесь экземпляру IObjView передавать ссылку на OpenObjectManager, а не подписываться
		 *		((IObjView)w).Completed += OpenObjectManager_Completed;
		 */
		private void createView(Obj o)
		{
			var w = new ObjForm(o);
			((IEntityInstanceWindow)w).Completed += OpenObjectManager_Completed;
			_openObjects.Add(w);
			OpenWindowsCountChanged?.Invoke(this, _openObjects.Count);
			w.Show();
		}

		private void OpenObjectManager_Completed(object sender, ViewResponce<Obj> e)
		{
			var v = (IEntityInstanceWindow)(sender as ObjForm);
			v.Completed -= OpenObjectManager_Completed;

			if (e.Ok)
			{
				Save?.Invoke(this, e.Data);
			}

			_openObjects.Remove(v);
			OpenWindowsCountChanged?.Invoke(this, _openObjects.Count);
		}
	}
}
