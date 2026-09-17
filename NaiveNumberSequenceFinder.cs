
/// <summary>
/// A class that finds valid number sequences in a string using a naive approach.
/// </summary>
class NaiveNumberSequenceFinder
{

	/// <summary>
	/// Finds and prints all valid number sequences in the input string that start and end with the same digit.
	/// A valid number sequence is defined as a sequence of digits that starts and ends with the same digit, with no non-digit characters in between.
	/// </summary>
	/// <param name="input">The input string to search through.</param>
	/// <returns>The sum of all valid number sequences found in the input string.</returns>
	public static long Find(string input)
	{

		long sum = 0;

		// iterate every character in the input string
		for (int i = 0; i < input.Length; i++)
		{

			// Iterate through the following characters to find a a matching end digit
			char startDigit = input[i];
			for (int j = i + 1; j < input.Length; j++)
			{
				// non-digit characters are not allowed inside a valid number sequence
				if (!char.IsDigit(input[j]))
				{
					break;
				}

				// if we find a matching end digit, extract the number sequence and add it to the sum
				if (input[j] == startDigit)
				{
					string numberSequence = input.Substring(i, j - i + 1);
					sum += long.Parse(numberSequence);

					ConsoleHelpers.PrintHighlightedMatch(input, i, j);

					break;
				}
			}
		}
		return sum;
	}

}