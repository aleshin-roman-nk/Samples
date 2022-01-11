using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	public interface IMainView
	{
		event EventHandler<Obj> OpenDoc;
		void Display(IEnumerable<Obj> objs);
		int OpenWindowCount { get;set; }
	}
}
