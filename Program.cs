// See https://aka.ms/new-console-template for more information

class Labb1
{
	const string DEFAULT_INPUT = "29535123p48723487597645723645";

	public static void Main(string[] args)
	{
		string input = DEFAULT_INPUT;

		// check if string is passed as an argument or prompt the user for input
		if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
		{
			input = args[0];
		}
		else
		{
			string userInput = RequestUserInput();
			input = string.IsNullOrEmpty(userInput) ? DEFAULT_INPUT : userInput;
		}

		PrintPreamble(input);

		long sum = NaiveNumberSequenceFinder.Find(input);
		
		PrintResults(sum);
	}

	public static string RequestUserInput()
	{
		Console.WriteLine("Enter a string to search through or [Enter] to use the default string:");
		string userInput = Console.ReadLine() ?? string.Empty;
		Console.WriteLine($"You entered: {userInput}");
		return userInput;
	}

	public static void PrintPreamble(string input)
	{
		Console.WriteLine("Input used: ");
		Console.WriteLine(input);
		Console.WriteLine("==========");
		Console.WriteLine();

	}

	public static void PrintResults(long sum)
	{
		Console.WriteLine();
		Console.WriteLine("==========");
		Console.WriteLine($"Sum of all valid number sequences: {sum}");
	}

}

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
			string numberSequence;
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
					numberSequence = input.Substring(i, j - i + 1);
					sum += long.Parse(numberSequence);

					PrintHighlightedMatch(input, i, j);

					break;
				}
			}
		}
		return sum;
	}

	/// <summary>
	/// Prints the input string with the matched number sequence highlighted.
	/// </summary>
	/// <param name="input">The input string to print.</param>
	/// <param name="startIndex">The starting index of the matched number sequence.</param>
	/// <param name="endIndex">The ending index of the matched number sequence.</param>
	/// <param name="matchColor">The color used for highlighting the matched number sequence (default is red).</param>
	public static void PrintHighlightedMatch(string input, int startIndex, int endIndex, ConsoleColor matchColor = ConsoleColor.Red)
	{
		Console.Write(input.AsSpan(0, startIndex));
		Console.ForegroundColor = matchColor;
		Console.Write(input.AsSpan(startIndex, endIndex - startIndex + 1));
		Console.ResetColor();
		Console.WriteLine(input.AsSpan(endIndex + 1));
	}
}
