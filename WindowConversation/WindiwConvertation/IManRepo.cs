using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindiwConvertation
{
	public interface IManRepo
	{
		IEnumerable<Man> GetAll();
		void Save(Man m);
	}
}
