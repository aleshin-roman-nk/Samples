using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	public interface IEntityInstanceWindow
	{
		int ObjId { get; }
		void Show();
		void Restore();
		event EventHandler<ViewResponce<Obj>> Completed;
	}
}