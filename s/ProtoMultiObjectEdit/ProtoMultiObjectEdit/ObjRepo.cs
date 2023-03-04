using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	public class ObjRepo
	{
		int _lastId = 0;
		List<Obj> _objects = new List<Obj>();
		public ObjRepo()
		{
			Create("Roman");
			Create("Nata");
			Create("Vital");
			Create("Spula");
		}

		public event EventHandler DbChanged;
		//public event EventHandler<Obj> ObjCreated;

		private void OnObjChanged()
		{
			DbChanged?.Invoke(this, EventArgs.Empty);
		}

		public IEnumerable<Obj> GetAll()
		{
			return _objects;
		}

		public Obj Create(string d)
		{
			var o = new Obj { data = d, id = ++_lastId };
			_objects.Add(o);
			OnObjChanged();
			return o;
		}

		public Obj Save(Obj o)
		{
			OnObjChanged();
			return o;
		}

		public void Delete(Obj o)
		{
			_objects.Remove(o);
			OnObjChanged();
		}
	}
}
