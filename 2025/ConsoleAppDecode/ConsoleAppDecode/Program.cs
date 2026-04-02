using ConsoleAppDecode;
using System.Text;
using Decoder = ConsoleAppDecode.Decoder;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

while (true)
{
	Console.Write(">");

	var inPut = Console.ReadLine();

	if (string.IsNullOrEmpty(inPut)) continue;

	if (inPut.ToLower().Equals("clr"))
	{
		Console.Clear();
		continue;
	}

	try
	{
		var res = Decoder.Decode(encoded: inPut);
		Console.WriteLine(res);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
//		throw;
	}
}