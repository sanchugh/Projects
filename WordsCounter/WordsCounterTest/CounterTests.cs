using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CounterLib;
using System.Collections.Generic;

namespace WordsCounterTest
{
    [TestClass]
    public class CounterTests
    {
        [TestMethod]
        public void CountWordsTest()
        {
            string inputSentence = "This is a statement, and so is this.";
            var expectedOutput = new Dictionary<string, int>();
            expectedOutput.Add("this", 2);
            expectedOutput.Add("is", 2);
            expectedOutput.Add("a", 1);
            expectedOutput.Add("statement", 1);
            expectedOutput.Add("and", 1);
            expectedOutput.Add("so", 1);

            var counter = new Counter();

            var actualOutput = counter.CountWords(inputSentence);

            // check number of items are equal in both collection
            Assert.AreEqual(expectedOutput.Count, actualOutput.Count);

            // each key should present in expected result and their values (number of times words) should match
            foreach(var item in expectedOutput)
            {
                string key = item.Key;
                Assert.AreEqual(expectedOutput[key], actualOutput[key]);
            }
        }
    }
}
