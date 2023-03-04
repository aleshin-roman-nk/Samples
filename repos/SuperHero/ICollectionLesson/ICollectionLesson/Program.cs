

List<int> ccc = new List<int>();

changeCollection cwork = new changeCollection(ccc);
cwork.run();

foreach (int i in ccc)
{
    Console.WriteLine(i);
}


Console.ReadLine();

class changeCollection
{
    private readonly ICollection<int> c;

    public changeCollection(ICollection<int> c)
    {
        this.c = c;
    }

    public void run()
    {
        c.Add(1);
        c.Add(2);
    }
}