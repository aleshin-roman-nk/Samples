using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindiwConvertation
{
	public class ManRepo : IManRepo
	{
		List<Man> _men;

		public ManRepo()
		{
			_men = new List<Man>
			{
				new Man{Name = "Roman"},
				new Man{Name = "Nata"},
				new Man{Name = "Vital"},
				new Man{Name = "Shpula"}
			};
		}

		public IEnumerable<Man> GetAll()
		{
			return _men;
		}

		public void Save(Man m)
		{
			throw new NotImplementedException();
		}
	}
}
