using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DNA.Service
{
    public class NodeRepo
    {
        private readonly MyDbContext dbContext;

        public NodeRepo(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ForParent AsParent(DNode n)
        {
            return new ForParent(n, dbContext);
        }

        public DNode Get(int id)
        {
            var lst = dbContext._loadDb();

            return lst.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DNode> GetNodesByDNA(int id)
        {
            var lst = dbContext._loadDb();

            var sstr = $"-{id}-";

            return lst.Where(x => x.DNA.Contains(sstr)).OrderBy(x => x.DNA).ToList();
        }

        public IEnumerable<DNode> DNAToArray(DNode n)
        {
            if(n == null) return new List<DNode>();
            if (n.DNA == "-") return new List<DNode>();

            var lst = dbContext._loadDb();

            var res = n.DNA.Trim('-').Split('-').Select(x => int.Parse(x)).ToArray();

            var r = lst.Where(x => res.Contains(x.Id)).ToArray();

            return r;
        }

        //public void forEach(DNode _parentNode, )
        //{
        //    /*
        //     * 
        //     * 
        //     * 
        //     */
        //}
    }
}
