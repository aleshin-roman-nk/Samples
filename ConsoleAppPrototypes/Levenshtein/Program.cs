
Console.WriteLine(IsSimilar("Kolya hit Petya", "kolya hit petya", 95)); 



Console.ReadLine();



bool IsSimilar(string str1, string str2, int thresholdPercentage)
{
	str1 = str1.Trim().ToLower();
	str2 = str2.Trim().ToLower();

	int levenshteinDistance = GetLevenshteinDistance(str1, str2);
	int maxLength = Math.Max(str1.Length, str2.Length);
	int similarityPercentage = (int)((1 - (double)levenshteinDistance / maxLength) * 100);

	Console.WriteLine($"sovpadenie: {similarityPercentage}%");

	return similarityPercentage >= thresholdPercentage;
}

int GetLevenshteinDistance(string str1, string str2)
{
	int n = str1.Length;
	int m = str2.Length;
	int[,] dp = new int[n + 1, m + 1];

	if (n == 0) return m;
	if (m == 0) return n;

	for (int i = 0; i <= n; dp[i, 0] = i++) { }
	for (int j = 0; j <= m; dp[0, j] = j++) { }

	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			int cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;

			dp[i, j] = Math.Min(
				Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
				dp[i - 1, j - 1] + cost);
		}
	}

	return dp[n, m];
}