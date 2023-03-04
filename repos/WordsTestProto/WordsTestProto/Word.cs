using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTestProto
{
    internal class Word
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<WordMeaning> Meanings { get; set; }
    }
}
