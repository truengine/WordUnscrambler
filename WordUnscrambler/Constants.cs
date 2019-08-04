using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
	class Constants
	{
		public const string Options = "Enter scrambled words manually or as a file: F- file/M- manual";
		public const string OptionsContinue = "Continue? Y/N";

		public const string EnterFile = "Enter file path";
		public const string EnterManual = "Enter words comma separated: ";
		public const string InvalidOption = "Option not valid";

		public const string ErrorUnloadable = "words not loadable";
		public const string ErrorTerminated = "program will quit: ";

		public const string MatchFound = "match found for {0} {1}";
		public const string MatchNotFound = "no matches!";

		public const string Yes = "Y";
		public const string No = "N";
		public const string File = "F";
		public const string Manual = "M";

		public const string wordListFileName = "wordlist.txt";
	}
}
