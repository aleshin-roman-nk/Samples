// See https://aka.ms/new-console-template for more information
using MVPRouting;
using System.Security.Cryptography.X509Certificates;

//Console.WriteLine("Hello, World!");

//HUB h = new HUB();

//h.AddMember<NodeService>();
//h.AddMember<NodeViewClient>();

//foreach (var item in h._members)
//{
//    Console.WriteLine(item.GetType().Name);
//}

//HUBCommanMapper commanMapper = new HUBCommanMapper();

//// На стороне презентера настраиваем строковые команды
//commanMapper.AddRoute("create-node", x =>
//{
//    int id = (int)x;
//    return 2 + 2 + id;
//});

//commanMapper.AddRoute("create-node-srv", x =>
//{
//    Console.WriteLine("We are in task controller service");
//    return new { name = "Roman", id = (int)x };
//});

//// На стороне OpenObjectManager вызываем команды
//try
//{
//    Console.WriteLine(commanMapper.Send("create-node", 16));
//    Console.WriteLine(commanMapper.Send("create-node-srv", 16));
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

//Cld c = new Cld();
//foreach (var item in c.Values)
//{
//    Console.WriteLine(item);
//}


NodesFactory factory = new NodesFactory();
factory.AddNodeType<Par>();
factory.AddNodeType<Cld>();
factory.AddNodeType<NodeYTask>();

//foreach (var item in factory.Members)
//{
//    Console.WriteLine(item);
//}

var o = factory.CreateNode("NodeYTask");
Console.WriteLine(o);

Console.ReadLine();

class Par
{
    public IEnumerable<string> Values { get; set; }
    public Par()
    {
        Values = new List<string>
        {
            "Roman",
            "Nata"
        };

    }
}

class Cld: Par
{

}

class NodeYTask
{
    public int id { get; set; } 
    public string name { get; set; }

    public NodeYTask()
    {
        Console.WriteLine("I am NodeYTask");
    }
}