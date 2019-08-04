using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Test.Unit
{
	[TestClass]
	public class WordMatcherTest
	{
		private readonly WordMatcher _wordMatcher = new WordMatcher();
		[TestMethod]
		public void hasMatch()
		{
			string[] list = { "cat", "b", "more"};
			string[] word = { "omre" };

			var matched = _wordMatcher.Match(word, list);

			Assert.IsTrue(matched.Count == 1);
			Assert.IsTrue(matched[0].ScrambledWord.Equals("omre"));
			Assert.IsTrue(matched[0].Word.Equals("more"));
		}

		[TestMethod]
		public void hasMatches()
		{
			string[] list = { "cat", "b", "more" };
			string[] word = { "omre", "act" };

			var matched = _wordMatcher.Match(word, list);

			Assert.IsTrue(matched.Count == 2);
			Assert.IsTrue(matched[0].ScrambledWord.Equals("omre"));
			Assert.IsTrue(matched[0].Word.Equals("more"));
			Assert.IsTrue(matched[1].ScrambledWord.Equals("act"));
			Assert.IsTrue(matched[1].Word.Equals("cat"));
		}


	}
}
