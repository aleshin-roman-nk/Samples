// See https://aka.ms/new-console-template for more information

using CG.Web.MegaApiClient;

Console.WriteLine("Hello, World!");

MegaApiClient client = new MegaApiClient();
client.Login("kalinovsky@protonmail.com", "xoxol1914fg5443");

IEnumerable<INode> nodes = client.GetNodes();

INode myFolder;

INode root = nodes.Single(x => x.Type == NodeType.Root);
var ufld = client.GetNodes(root).FirstOrDefault(x => x.Name == "Upload");
if(ufld == null)
{
    myFolder = client.CreateFolder("Upload", root);
}
else
{
    myFolder = ufld;
}

INode myFile = client.UploadFile("w_U_202206.pdf", myFolder);
Uri downloadLink = client.GetDownloadLink(myFile);
Console.WriteLine(downloadLink);

client.Logout();

Console.ReadLine();