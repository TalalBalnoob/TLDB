using System;
using TLDB.Classes;
using TLDB.Enums;

class Program {
	static void Main(string[] args) {
		while (true) {
			Console.Write("db > ");
			string? input = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(input.Trim()))
				continue;

			// 1️⃣ Meta commands
			if (input.StartsWith(".")) {
				var metaResult = DoMetaCommand(input);

				if (metaResult == MetaCommandResult.UnrecognizedCommand)
					Console.WriteLine($"Unrecognized command '{input}'");

				continue;
			}

			// 2️⃣ Prepare statement
			var statement = new Statement();
			var prepareResult = PrepareStatement(input, statement);

			if (prepareResult == PrepareResult.UnrecognizedStatement) {
				Console.WriteLine($"Unrecognized keyword at start of '{input}'.");
				continue;
			}

			// 3️⃣ Execute statement
			ExecuteStatement(statement);
			Console.WriteLine("Executed.");
		}
	}

	static MetaCommandResult DoMetaCommand(string input) {
		if (input == ".exit") {
			Environment.Exit(0);
			return MetaCommandResult.Success; // never reached
		}

		return MetaCommandResult.UnrecognizedCommand;
	}

	static PrepareResult PrepareStatement(string input, Statement statement) {
		if (input.StartsWith("insert")) {
			statement.Type = StatementType.Insert;
			return PrepareResult.Success;
		}

		if (input == "select") {
			statement.Type = StatementType.Select;
			return PrepareResult.Success;
		}

		return PrepareResult.UnrecognizedStatement;
	}

	static void ExecuteStatement(Statement statement) {
		switch (statement.Type) {
			case StatementType.Insert:
				Console.WriteLine("This is where we would do an insert.");
				break;

			case StatementType.Select:
				Console.WriteLine("This is where we would do a select.");
				break;
		}
	}
}
