using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNA.Service
{
    public class SessionRepo : IPartOfTreeFlatRepo
    {
        private readonly MyDbContext dbContext;

        DNode _parentNodeA;

        public SessionRepo(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IPartOfTreeFlatRepo OfParent(DNode n)
        {
            _parentNodeA = n;
            return this;
        }

        public void Create(string obj)
        {
            Console.WriteLine($"We have created a Session object '{obj}' of parent '{_parentNodeA.Name}'");
        }
    }
}
