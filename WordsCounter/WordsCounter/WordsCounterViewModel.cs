using CounterLib;
using DevExpress.Mvvm;
using System;
using System.Text;

namespace WordsCounter
{
    public class WordsCounterViewModel : ViewModel
    {
        private string _sentence;
        private string _outputText;
        public DelegateCommand<string> CheckDuplicateWords { get; set; }

        public WordsCounterViewModel()
        {
            BuildCommands();
        }

        private void BuildCommands()
        {
            CheckDuplicateWords = new DelegateCommand<string>(x => CheckDuplicates());
        }

        private void CheckDuplicates()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Sentence))
                {
                    OutputText = "\n Input sentence is blank, please enter sentence";
                }
                else
                {
                    var counter = new Counter();
                    var result = counter.CountWords(Sentence);

                    StringBuilder output = new StringBuilder();
                    foreach (var item in result)
                        output.Append("\n" + item.Key + " - " + item.Value);

                    OutputText = output.ToString();
                }
            }
            catch(Exception ex)
            {
                OutputText = "Error while checking duplicates ! " + ex.Message;
                // log the detailed error message with stack trace
            }
        }

        /// <summary>
        /// Input Sentence
        /// </summary>
        public string Sentence
        {
            get
            {
                return _sentence;
            }
            set
            {
                _sentence = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Output 
        /// </summary>
        public string OutputText
        {
            get
            {
                return _outputText;
            }
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }
    }
}
