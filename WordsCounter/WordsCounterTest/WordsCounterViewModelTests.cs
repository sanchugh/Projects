using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CounterLib;
using System.Collections.Generic;
using WordsCounter;

namespace WordsCounterTest
{
    [TestClass]
    public class WordsCounterViewModelTests
    {
        [TestMethod]
        public void CheckDuplicatesTest()
        {
            var wc = new WordsCounterViewModel();

            wc.Sentence = "This is a statement, and so is this.";

            string expectedOutputText = "this - 2\nis - 2\na - 1\nstatement - 1\nand - 1\nso - 1\n";

            wc.CheckDuplicates();

            Assert.AreEqual(expectedOutputText, wc.OutputText);

        }
        [TestMethod]
        public void CheckDuplicatesTestWithNoValidWord()
        {
            var wc = new WordsCounterViewModel();

            wc.Sentence = ";;;;;";

            string expectedOutputText = "No valid word found";

            wc.CheckDuplicates();

            Assert.AreEqual(expectedOutputText, wc.OutputText);

        }
        [TestMethod]
        public void CheckDuplicatesTestWithException()
        {
            try
            {
                var wc = new WordsCounterViewModel();

                wc.Sentence = null;

                wc.CheckDuplicates();

                Assert.IsTrue(wc.OutputText.Contains("Error while checking duplicates"));

            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

    }
}
