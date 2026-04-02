using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleAppDecode
{
	public static class Decoder
	{
		// Русский алфавит с Ё (А=1 ... Я=33)
		private static readonly char[] Ru =
		{
		'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'
	};

		public static string Decode(string encoded)
		{
			if (string.IsNullOrWhiteSpace(encoded))
				return string.Empty;

			var parts = encoded.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length < 2)
				throw new FormatException("Ожидается минимум: <число+буква> <число> ...");

			// 1) Первый токен вида "1л" или "12л"
			string first = parts[0];

			int i = 0;
			while (i < first.Length && char.IsDigit(first[i])) i++;

			if (i == 0 || i >= first.Length)
				throw new FormatException("Первый токен должен быть вида <число><буква>, например: 1л.");

			int firstNum = int.Parse(first.Substring(0, i), CultureInfo.InvariantCulture);
			char literal = first[i]; // буква "как есть" (может быть 'л', 'Л', и т.д.)

			var result = new List<char>(16);

			// число -> буква (в верхнем регистре)
			result.Add(NumToRuUpper(firstNum));
			// буква -> как есть
			result.Add(literal);

			// 2) Остальные токены — числовые группы. Последнюю игнорируем.
			for (int p = 1; p < parts.Length - 1; p++)
			{
				int n = int.Parse(parts[p], CultureInfo.InvariantCulture);
				result.Add(NumToRuUpper(n));
			}

			// В примере добавлена точка в конце
			//result.Add('.');

			return new string(result.ToArray());
		}

		private static char NumToRuUpper(int n)
		{
			if (n < 1 || n > Ru.Length)
				throw new ArgumentOutOfRangeException(nameof(n), $"Номер буквы вне диапазона 1..{Ru.Length}.");

			return Ru[n - 1];
		}
	}
}
