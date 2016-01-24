using System.Collections.Generic;
using System.Linq;

namespace CounterLib
{
    public class Counter : ICounter
    {
        /// <summary>
        /// This method will accept the input sentence and returns the collection of all the words and their count 
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public Dictionary<string, int> CountWords(string sentence)
        {
            Dictionary<string, int> countedWords = new Dictionary<string, int>();

            string newSentence = RemoveSpecialChar(sentence);

            string[] allWords = newSentence.Split(' ');

            // remove words with empty spaces and change all the words to lower case 
            string[] words = allWords.Where(word => !string.IsNullOrEmpty(word)).Select(word => word.ToLower()).ToArray();

            foreach (var word in words)
            {
                if (countedWords.Keys.Contains(word))
                {
                    countedWords[word] = countedWords[word] + 1;
                }
                else
                {
                    countedWords.Add(word, 1);
                }
            }

            return countedWords;
        }

        private string RemoveSpecialChar(string sentence)
        {
            char[] ignoredSpecialChar = new char[] { '.', ',', ';', ':', '?', '!', '"','\r','\n' }; // assuming these special chars not part of word, these can be added or removed based on the fact which one author want to consider part of the word, can be configured  
            foreach (char sp in ignoredSpecialChar)
            {
                if (sentence.Contains(sp))
                    sentence = sentence.Replace(sp, ' ');
            }
            return sentence;
        }
    }
}
