using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DNA.Service
{
    public class MyDbContext
    {
        private readonly string fname;

        public MyDbContext(string fname)
        {
            this.fname = fname;
        }

        public List<DNode>? _loadDb()
        {
            if (File.Exists(fname))
            {
                string j = File.ReadAllText(fname, Encoding.UTF8);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<DNode>>(j);
            }
            else return new List<DNode>();
        }

        public void SaveChanges(List<DNode>? listDb)
        {
            string j = Newtonsoft.Json.JsonConvert.SerializeObject(listDb, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fname, j, Encoding.UTF8);
        }
    }
}
