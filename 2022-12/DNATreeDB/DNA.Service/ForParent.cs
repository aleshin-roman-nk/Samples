using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DNA.Service
{

    // All features that a node can have.
    public class ForParent
    {
        private readonly DNode _parentNode;
        private readonly MyDbContext db;

        public ForParent(DNode n, MyDbContext db)
        {
            this._parentNode = n;
            this.db = db;
        }

        public void Create(DNode n)
        {
            var lst = db._loadDb();
            n.Id = lst.Count() + 1;

            DNode p = null;

            if (_parentNode != null)
                p = lst.FirstOrDefault(x => x.Id == _parentNode.Id);

            if (p != null)
            {
                n.DNA = $"{p.DNA}{n.Id}-";
                n.parentId = p.Id;
            }
            else
            {
                n.DNA = $"-{n.Id}-";
                n.parentId = 0; // making sure we do not fool around
            }

            lst.Add(n);

            db.SaveChanges(lst);
        }


        // в xorg е нужен метод SaveRange который испрользуется для обновления id коллекции узлов при переносе
        // так как все сохранения выполняются хдесь сразу
        public void Move(IEnumerable<DNode> nodes)
        {
            var lst = db._loadDb();

            Console.WriteLine(_parentNode == null ? "node-root" : _parentNode.Name);

            Func <DNode, IEnumerable<DNode>> getChildren = (parent) =>
            {
                return lst.Where(x => x.parentId == parent.Id).ToList();
            };

            // базовый уровень
            foreach (var node in nodes)
            {
                Console.Write($"p:{node.parentId}; dna:{node.DNA} => ");

                node.DNA = _parentNode == null ? $"-{node.Id}-" : $"{_parentNode.DNA}{node.Id}-";
                node.parentId = _parentNode == null ? 0 : _parentNode.Id;

                Console.WriteLine($"p:{node.parentId}; dna:{node.DNA}");

                var parentsStack = new Stack<DNode>();

                parentsStack.Push(node);

                // одно поколение узлов должно брать днк из предидущего поколения узлов
                while (parentsStack.Any())
                {
                    var thisParent = parentsStack.Pop();// текущий родитель

                    // обход всех дочерних объектов и обновление днк
                    foreach (var child in getChildren(thisParent))
                    {
                        Console.Write($"p:{child.parentId}; dna:{child.DNA} => ");

                        child.DNA = $"{thisParent.DNA}{child.Id}-";
                        //child.parentId = thisParent == null ? 0 : thisParent.Id;

                        Console.WriteLine($"p:{child.parentId}; dna:{child.DNA}");

                        parentsStack.Push(child);
                    }
                }

            }
        }

        public void UpdateAllDNA()
        {
            var lst = db._loadDb();

            Console.WriteLine(_parentNode == null ? "node-root" : _parentNode.Name);

            Func<DNode, IEnumerable<DNode>> getChildren = (parent) =>
            {
                return lst.Where(x => x.parentId == parent.Id).ToList();
            };

            var nodes = lst.Where(x => x.parentId == 0).ToList();

            // корневые узлы
            foreach (var node in nodes)
            {
                Console.Write($"p:{node.parentId}; dna:{node.DNA} => ");

                node.DNA = $"-{node.Id}-";
                //node.DNA = _parentNode == null ? $"-{node.Id}-" : $"{_parentNode.DNA}{node.Id}-";
                //node.parentId = _parentNode == null ? 0 : _parentNode.Id;

                Console.WriteLine($"p:{node.parentId}; dna:{node.DNA}");

                var parentsStack = new Stack<DNode>();

                parentsStack.Push(node);

                // одно поколение узлов должно брать днк из предидущего поколения узлов
                while (parentsStack.Any())
                {
                    var thisParent = parentsStack.Pop();// текущий родитель

                    // обход всех дочерних объектов и обновление днк
                    foreach (var child in getChildren(thisParent))
                    {
                        Console.Write($"p:{child.parentId}; dna:{child.DNA} => ");

                        child.DNA = $"{thisParent.DNA}{child.Id}-";
                        //child.parentId = thisParent == null ? 0 : thisParent.Id;

                        Console.WriteLine($"p:{child.parentId}; dna:{child.DNA}");

                        parentsStack.Push(child);
                    }
                }

            }
        }

        public IPartOfTreeFlatRepo For(IPartOfTreeFlatRepo frepo)
        {
            //frepo.SetParent(_parentNode.Name);
            return frepo;
        }

        public void CreateTypeOf()// как создавать объекты, можно добавлять класс по поддобию OfParent
            // только еще шире: AsParentOf, но тут нужно ссылку на тот репозиторий, который отвечает за эту сущность.
        {

        }

        public IEnumerable<DNode> Children
        {
            get
            {
                var lst = db._loadDb();

                int parentId = _parentNode == null ? 0 : _parentNode.Id;

                return lst.Where(x => x.parentId == parentId).ToList();
            }
        }

        public void Save()
        {

        }

        //public ForParent ToParent()// Parent destination -> 
        //{

        //}
    }
}
