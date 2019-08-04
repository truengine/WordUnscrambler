using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
	 class Program
	{

		private static readonly FileReader _fileReader = new FileReader();
		private static readonly WordMatcher _wordMatcher = new WordMatcher();
		static void Main(string[] args)
		{
			try
			{


				bool continueWordUnscramble = true;
				do
				{
					Console.WriteLine(Constants.Options);
					var option = Console.ReadLine() ?? string.Empty;

					switch (option.ToUpper())
					{
						case Constants.File:
							Console.WriteLine(Constants.EnterFile);
							ExecuteScrambleFile();
							break;
						case Constants.Manual:
							Console.WriteLine(Constants.EnterManual);
							ExecuteScrambleManual();
							break;
						default:
							Console.Write(Constants.InvalidOption);
							break;
					}
					var continueDecision = string.Empty;
					do
					{
						Console.WriteLine(Constants.OptionsContinue);
						continueDecision = (Console.ReadLine() ?? string.Empty);

					} while (
					!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
					!continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));
					continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
				} while (continueWordUnscramble);
			}
			catch (Exception e)
			{
				Console.WriteLine(Constants.ErrorTerminated + e.Message);
			}
		}

		private static void ExecuteScrambleManual()
		{
			var manualInput = Console.ReadLine() ?? string.Empty;
			string[] scrambledWords = manualInput.Split(',');
			DisplayMatched(scrambledWords);
		}

		private static void ExecuteScrambleFile()
		{
			try
			{
				var filename = Console.ReadLine() ?? string.Empty;
				string[] scrambledWords = _fileReader.Read(filename);
				DisplayMatched(scrambledWords);
			}
			catch (Exception e)
			{
				Console.WriteLine(Constants.ErrorUnloadable + e.Message);
			}

		}

		private static void DisplayMatched(string[] scrambledWords)
		{
			string[] wordList = _fileReader.Read(Constants.wordListFileName);

			List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

			if (matchedWords.Any())
			{
				foreach (var match in matchedWords)
				{
					Console.WriteLine(Constants.MatchFound, match.ScrambledWord, match.Word);
				}
			}
			else
			{
				Console.WriteLine(Constants.MatchNotFound);
			}
		}
	}
}
 