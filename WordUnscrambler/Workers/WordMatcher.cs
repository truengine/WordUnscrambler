using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
	class WordMatcher
	{
		public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
		{
			var matchedWords = new List<MatchedWord>();

				foreach (var wd in scrambledWords)
				{
					foreach (var word in wordList)
					{
						if(wd.Equals(word, StringComparison.OrdinalIgnoreCase))
						{
							matchedWords.Add(BuildMatchedWord(wd, word));
						}
						else
						{
							var scrambledWdArray = wd.ToCharArray();
							var wordArray = word.ToCharArray();

							Array.Sort(scrambledWdArray);
							Array.Sort(wordArray);

							var sortedScrambledWd = new string(scrambledWdArray);
							var sortedWord = new string(wordArray);

							if(sortedScrambledWd.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
							{
								matchedWords.Add(BuildMatchedWord(wd, word));
							}

						}
					}
				}

			return matchedWords;
		}

		private MatchedWord BuildMatchedWord(string wd, string word)
		{
			MatchedWord matchedWord = new MatchedWord
			{
				ScrambledWord = wd,
				Word = word
			};

			return matchedWord;
		}
	}
}
