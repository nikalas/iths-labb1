
class NumberSequenceFinderIterator
{
	public static IEnumerable<(string NumberSequence, int StartIndex, int EndIndex)> Find(string input)
	{
		for (int i = 0; i < input.Length; i++)
		{
			char startDigit = input[i];
			for (int j = i + 1; j < input.Length; j++)
			{
				if (!char.IsDigit(input[j]))
				{
					break;
				}

				if (input[j] == startDigit)
				{
					string numberSequence = input.Substring(i, j - i + 1);
					yield return (numberSequence, i, j);
					break;
				}
			}
		}
	}
}