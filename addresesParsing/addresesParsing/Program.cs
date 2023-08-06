

using System.Text.RegularExpressions;

string[] inputStrings = {
            "УЛ МОЛОДЁЖНАЯ 2, 12, 22, 7, 17",
            "УЛ ЦЕНТРАЛЬНАЯ 12/1, 12/2, 7/1, 7/2, 17/1, 17/2",
            "УЛ БАКАЕВА 12",
            "ПЕР КАЛИНИНА 12/1, 23А, 34"
        };

List<TerritoryItem> territoryItems = new List<TerritoryItem>();

foreach (string inputString in inputStrings)
{
    TerritoryItem item = ParseTerritoryItem(inputString);
    territoryItems.Add(item);
}

// Print the results
foreach (TerritoryItem item in territoryItems)
{
    Console.WriteLine($"Street: {item.street}");
    Console.WriteLine($"Buildings: {string.Join(", ", item.buildings)}");
    Console.WriteLine();
}

Console.ReadLine();

TerritoryItem ParseTerritoryItem(string inputString)
{
    TerritoryItem item = new TerritoryItem();

    // Use regular expression to match street and buildings
    Regex regex = new Regex(@"^(?<street>[\w\s]+?)\s(?<buildings>.+)$");
    Match match = regex.Match(inputString);

    if (match.Success)
    {
        // Extract street
        item.street = match.Groups["street"].Value.Trim();

        // Extract buildings and split by comma or space
        string buildingsString = match.Groups["buildings"].Value;
        item.buildings = buildingsString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    return item;
}

class TerritoryItem
{
    public string street { get; set; }
    public string[] buildings { get; set; }
}

