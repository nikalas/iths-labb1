
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