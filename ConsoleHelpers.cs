
class ConsoleHelpers
{
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
		Console.WriteLine($"Sum of all valid number sequences: {sum}");
		Console.WriteLine("==========");
		Console.WriteLine();
	}
}