using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.dtoservices
{
    public class DtoMessage
    {
        public string from { get; }
        public string to { get; }
        public object data { get; }
        public string method { get; }

        public DtoMessage(string to, string method)
        {
            this.to = to;
            this.method = method;
        }

        public DtoMessage(string fr, string to, string method, object data)
        {
            from = fr;
            this.to = to;
            this.method = method;
            this.data = data;
        }

		public TDtoType CastData<TDtoType>() where TDtoType : class
		{
			return (TDtoType)data;
		}
	}
}
