class Labb1
{
	const string DEFAULT_INPUT = "29535123p48723487597645723645";

	public static void Main(string[] args)
	{
		string input = DEFAULT_INPUT;

		if (Array.Exists(args, arg => arg == "--help" || arg == "-h"))
		{
			Console.WriteLine("Usage: dotnet run [-u]");
			Console.WriteLine("-u: Unattended. Use hardcoded input string.");
			return;
		}

		if (!Array.Exists(args, arg => arg == "-u"))
		{
			string userInput = ConsoleHelpers.RequestUserInput();
			input = string.IsNullOrEmpty(userInput) ? DEFAULT_INPUT : userInput;
		}

		ConsoleHelpers.PrintPreamble(input);

		ExecuteNaiveFinder(input); // this is the actual assignment
		ExecuteClassFinder(input);
		ExecuteIteratorFinder(input); 

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();

	}

	public static void ExecuteNaiveFinder(string input)
	{
		Console.WriteLine();
		Console.WriteLine("Using naive implementation");

		ConsoleHelpers.PrintResults( NaiveNumberSequenceFinder.Find(input));
	}

	public static void ExecuteClassFinder(string input)
	{
		Console.WriteLine();
		Console.WriteLine("Using class implementation");

		var numberSequenceFinder = new NumberSequenceFinderClass(input);
		string current = numberSequenceFinder.Next();
		while (!string.IsNullOrEmpty(current))
		{
			int startIndex = numberSequenceFinder.CurrentIndex - 1;
			int endIndex = startIndex + current.Length - 1;
			ConsoleHelpers.PrintHighlightedMatch(
				input,
				startIndex,
				endIndex,
				ConsoleColor.Blue
			);
			current = numberSequenceFinder.Next();
		}
		ConsoleHelpers.PrintResults( numberSequenceFinder.Sum);
	}

	public static void ExecuteIteratorFinder(string input)
	{
		Console.WriteLine();
		Console.WriteLine("Using iterator implementation");

		long sum = 0;
		foreach (var (NumberSequence, StartIndex, EndIndex) in NumberSequenceFinderIterator.Find(input))
		{
			ConsoleHelpers.PrintHighlightedMatch(
				input,
				StartIndex,
				EndIndex,
				ConsoleColor.Green
			);
			sum += long.Parse(NumberSequence);
		}
		ConsoleHelpers.PrintResults( sum);
	}
}
