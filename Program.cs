// See https://aka.ms/new-console-template for more information

class Labb1
{
	const string DEFAULT_INPUT = "29535123p48723487597645723645";

	public static void Main(string[] args)
	{
		string input = DEFAULT_INPUT;


		var numberSequenceFinder = new NumberSequenceFinderClass(input);
		string current = numberSequenceFinder.Next();
		while (!string.IsNullOrEmpty(current))
		{
			// Console.WriteLine($"current index {numberSequenceFinder.CurrentIndex}, current number sequence: {current}");
			int startIndex = numberSequenceFinder.CurrentIndex -1;
			int endIndex = startIndex + current.Length - 1;
			NaiveNumberSequenceFinder.PrintHighlightedMatch(input, startIndex, endIndex);
			// Console.WriteLine(current);
			current = numberSequenceFinder.Next();
		}
		
		PrintResults(numberSequenceFinder.Sum);
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

class NumberSequenceFinderClass
{
	private readonly string _input;
	public int CurrentIndex { get; private set; } = 0;

	public long Sum { get; private set; } = 0;

	public NumberSequenceFinderClass(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
		}

		_input = input;
	}

	public string Next()
	{
		while (CurrentIndex < _input.Length)
		{
			char startDigit = _input[CurrentIndex];
			for (int j = CurrentIndex + 1; j < _input.Length; j++)
			{
				if (!char.IsDigit(_input[j]))
				{
					break;
				}

				if (_input[j] == startDigit)
				{
					string numberSequence = _input.Substring(CurrentIndex, j - CurrentIndex + 1);
					Sum += long.Parse(numberSequence);
					CurrentIndex++;
							
					return numberSequence;
				}
			}
			CurrentIndex++;
		}
		return string.Empty;
	}

	public void Reset()
	{
		CurrentIndex = 0;
		Sum = 0;
	}

}

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