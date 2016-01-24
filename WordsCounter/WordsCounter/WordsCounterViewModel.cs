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

        public void BuildCommands()
        {
            CheckDuplicateWords = new DelegateCommand<string>(x => CheckDuplicates(), x => CanExecute(x));
        }

        public bool CanExecute(string str)
        {
            if(string.IsNullOrWhiteSpace(Sentence))
            {
                OutputText = string.Empty;
                return false;
            }
            else
            {
                return true;
            }
        }
        public void CheckDuplicates()
        {
            try
            {
                var counter = new Counter();
                var result = counter.CountWords(Sentence);

                if(result.Count !=0)
                {
                    StringBuilder output = new StringBuilder();
                    foreach (var item in result)
                        output.Append(item.Key + " - " + item.Value + "\n");

                    OutputText = output.ToString();
                }
                else
                {
                    OutputText = "No valid word found";
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
        /// Output (Binded as a simple text to the UI for the simplicity to show it similar to the example however it can be bind to other controls like ListView and GridView)
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
