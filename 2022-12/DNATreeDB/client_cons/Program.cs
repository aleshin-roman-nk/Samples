// See https://aka.ms/new-console-template for more information

using DNA.Service;
using System.Text;

var db = new MyDbContext("nodes.json");

NodeRepo _repo = new NodeRepo(db);
SessionRepo _sessRepo = new SessionRepo(db);

DNode? _currentNode = null;
//IEnumerable<DNode> _currentNodes = null;

string? cmd = string.Empty;

//string rrr = "c funny-child";
//var res = rrr.Split();

//var res = "-1-2-3-".Trim('-').Split('-');

while( !cmd.Equals("exit"))
{

    var c = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    //Console.Write(_currentNode == null ? ">" : $"{_currentNode.Name}>");
    Console.Write(getPath(_currentNode));
    cmd = Console.ReadLine();
    Console.ForegroundColor = c;

    if ("dir".Equals(cmd.ToLower()))
    {
        showNodes();
    }
    else if (cmd.StartsWith("create"))
    {
        createNode(cmd);
    }
    else if (cmd.StartsWith("cd"))
    {
        enterNode(cmd);
    }
    else if (cmd.StartsWith("dna"))
    {
        showNodesOfDNA(cmd);
    }
    else if (cmd.StartsWith("sess"))
    {
        showSessCreated();
    }
    else if (cmd.StartsWith("moveto"))
    {
        moveTo();
    }
    else if (cmd.StartsWith("updatedna"))
    {
        dna_update();
    }
}

void dna_update()
{
    _repo.AsParent(null).UpdateAllDNA();
}

void moveTo()
{
    string[] el = cmd.Split();

    IEnumerable<DNode> lst = _repo.AsParent(_currentNode).Children;

    //_repo.AsParent(_currentNode).For(_sessRepo).Create($"{el[1]}");

    var parent = _repo.Get(int.Parse(el[1]));

    _repo.AsParent(parent).Move(lst);
}

void showSessCreated()
{
    string[] el = cmd.Split();

    //_repo.AsParent(_currentNode).For(_sessRepo).Create($"{el[1]}");

    _sessRepo.OfParent(_currentNode).Create($"{el[1]}");
}

Console.WriteLine("bye");
Console.ReadLine();

// As I choosed the code way like this, I shoud follow it.
// Такую стилистику кода можно применить только к древовидному репозиторию.
// А можно даже некий дженерик сделать.
// ВОТ: выделить время на разработку полного api для древовидного репозитория.
// 
//_repo.OfParent(_currentNode)
//    .CreateChild(new DNode { Name = "lll"})
//    .Save();

//var c = _repo.OfParent(_currentNode).Children;

string getPath(DNode d)
{
    if (d == null) return ">";
 
    StringBuilder sb = new StringBuilder();

    foreach (var item in _repo.DNAToArray(d))
    {
        sb.Append($"{item.Name}/");
    }

    sb.Append(">");

    return sb.ToString();
}

void showNodes()
{
    IEnumerable<DNode> lst = _repo.AsParent(_currentNode).Children;

    foreach (var item in lst)
    {
        Console.WriteLine($"#{item.Id} {item.Name} DNA: {item.DNA}");
    }
}

void createNode(string cmd)
{
    string[] el = cmd.Split();

    _repo.AsParent(_currentNode).Create(new DNode { Name = el[1] });
}

void enterNode(string cmd)
{
    string[] el = cmd.Split();

    if (el[1].Equals(".."))
    {
        _currentNode = _repo.Get(_currentNode.parentId);
    }
    else
        _currentNode = _repo.Get(int.Parse(el[1]));
}

void showNodesOfDNA(string cmd)
{
    string[] el = cmd.Split();

    var lst = _repo.GetNodesByDNA(int.Parse(el[1]));

    foreach (var item in lst)
    {
        Console.WriteLine($"#{item.Id} {item.Name} DNA: {item.DNA}");
    }
}