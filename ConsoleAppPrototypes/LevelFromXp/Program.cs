

string enter = "";

int xp = 0;

while(enter != "end")
{
	Console.Write("> ");
	enter = Console.ReadLine();

	if(int.TryParse(enter, out xp))
	{
        Console.WriteLine($"xp: {xp}; level: {CalculateLevel(xp)}");
	}
}

Console.ReadLine();




int CalculateLevel(int xp)
{
	// Define parameters for the exponential function
	double baseXP = 100; // Example base XP required for level 2
	double xpMultiplier = 1.5; // Example multiplier for XP required for each subsequent level

	// Calculate the level using an exponential function
	int level = 1;
	double xpRequired = baseXP;
	while (xp >= xpRequired)
	{
		level++;
		xpRequired = baseXP * Math.Pow(xpMultiplier, level - 1);
	}
	return level;
}