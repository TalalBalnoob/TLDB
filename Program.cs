using System;

class Program {
	static void Main(string[] args) {
		while (true) {
			PrintPrompt();

			string? input = Console.ReadLine().Trim();

			if (string.IsNullOrWhiteSpace(input))
				continue;

			if (input == ".exit") {
				break;
			}
			else {
				Console.WriteLine($"Unrecognized command '{input}'.");
			}
		}
	}

	static void PrintPrompt() {
		Console.Write("db > ");
	}
}
