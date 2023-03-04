using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNA.Service
{
    public interface IPartOfTreeFlatRepo
    {
        void Create(string obj);
        IPartOfTreeFlatRepo OfParent(DNode n);
    }
}
