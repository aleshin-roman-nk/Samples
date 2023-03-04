using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace CatsRestAPILesson
{
    public class CatsModel
    {
        List<Cat>? Cats;

        public CatsModel()
        {
            if (System.IO.File.Exists("cats.json"))
            {
                string j = File.ReadAllText("cats.json", System.Text.Encoding.UTF8);
                Cats = JsonConvert.DeserializeObject<List<Cat>>(j);
            }
            else
            {
                Cats = new List<Cat>();
            }
        }

        public void Add(Cat c)
        {
            c.id = Cats.Count() + 1;
            Cats.Add(c);
            string j = JsonConvert.SerializeObject(Cats, Formatting.Indented);

            File.WriteAllText("cats.json", j, System.Text.Encoding.UTF8);
        }

        public IEnumerable<Cat>? GetCatsOf(int parentid)
        {
            return Cats.Where(x => x.parentId == parentid).ToArray();
        }

        public Cat? GetSingle(int catid)
        {
            return Cats.FirstOrDefault(x => x.id == catid);
        }

        public void AddProperty(int catid, string catproperty)
        {
            var c = Cats.FirstOrDefault(x => x.id == catid);

            if (c != null)
            {
                c.CatProperties.Add(new CatProperty { Name = catproperty, CatId = catid, Id = c.CatProperties.Count() + 1});
                string j = JsonConvert.SerializeObject(Cats, Formatting.Indented);
                File.WriteAllText("cats.json", j, System.Text.Encoding.UTF8);
            }
        }

        public string GetFullPath(int catid)
        {
            if (catid == 0) return "/";

            var c = Cats.FirstOrDefault(x => x.id == catid);

            Stack<string> stack = new Stack<string>();

            while(c != null)
            {
                stack.Push($" {c.name} / ");
                c = Cats.FirstOrDefault(x => c.parentId == x.id);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in stack)
            {
                sb.Append(item);
            }

            return sb.ToString().TrimEnd(' ').TrimEnd('/');
        }

        public IEnumerable<Cat> GetAllParents(int catid)
        {
            Stack<Cat> res = new Stack<Cat>();

            if (catid == 0)
                return res.ToArray();

            var c = Cats.FirstOrDefault(x => x.id == catid);

            if (c == null)
                return res.ToArray();

            c = Cats.FirstOrDefault(x => c.parentId == x.id);

            while (c != null)
            {
                res.Push(c);
                c = Cats.FirstOrDefault(x => c.parentId == x.id);
            }

            return res.ToArray();
        }

    }
}
