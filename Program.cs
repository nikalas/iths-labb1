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

class NaiveNumberSequenceFinder
{

	/**
	 * Finds and prints all valid number sequences in the input string that start and end with the same digit.
	 * @param input The input string to search through.
	 * @return The sum of all valid number sequences found in the input string.
	 */
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

					// write whole string but highlight current match
					Console.Write(input.AsSpan(0, i));
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(numberSequence);
					Console.ResetColor();
					Console.WriteLine(input.AsSpan(j+1));

					break;
				}
			}
		}
		return sum;
	}
}
