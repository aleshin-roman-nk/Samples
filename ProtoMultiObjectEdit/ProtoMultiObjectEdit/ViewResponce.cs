using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoMultiObjectEdit
{
	public class ViewResponce<TData>
	{
		public bool Ok { get; set; }
		public TData Data { get; set; }
	}
}
