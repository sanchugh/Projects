using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterLib
{
    interface ICounter
    {
        Dictionary<string, int> CountWords(string sentence);
    }
}
