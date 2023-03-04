using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsTestProto
{
    internal class WordTest
    {
        private List<Word> _words = new List<Word>();
        public IEnumerable<Word> Words => _words;
        List<decimal> Grades = new List<decimal>();

        public bool Passed
        {
            get
            {
                if (Grades.Count <= 5) return false;

                if (Grades.Average(x => (decimal)x) < 75) return false;

                return true;
            }
        }

        int currentPoint = 0;
        decimal currentTestingSumm = 0;

        public void StartTest()
        {
            currentPoint = 0;
            currentTestingSumm = 0;
        }

        public void CheckAndNext(string txt)
        {
            StringBuilder sb = new StringBuilder();
            Words.ElementAt(currentPoint).Meanings.ForEach(x => sb.Append($"{x.text};"));

            var ch = Words.ElementAt(currentPoint).Meanings.FirstOrDefault(x => x.text.Equals(txt)) != null;

            if (ch)
            {
                currentPoint++;
                currentTestingSumm += 100.0m / _words.Count;

                Console.WriteLine($"Ok, total: {currentTestingSumm}");
            }
            else
            {
                currentPoint++;
                Console.WriteLine($"Error, right answer: {sb.ToString()}");
            }

            if(currentPoint == _words.Count)
            {
                Grades.Add(currentTestingSumm);
            }
        }

        public decimal TotalLastTest()
        {
            return currentTestingSumm;
        }

        public string CurrentQuestion()
        {
            return Words.ElementAt(currentPoint).text;
        }

        public bool TestIsOver()
        {
            return currentPoint == _words.Count;
        }

        public WordTest()
        {
            _words.Add(
                new Word
                {
                    id = 1,
                    text = "go",
                    Meanings = new List<WordMeaning> {
                        new WordMeaning{id = 1, text = "идти", wordId = 1}
                    }
                });

            _words.Add(
                new Word
                {
                    id = 2,
                    text = "let",
                    Meanings = new List<WordMeaning> {
                                    new WordMeaning{id = 2, text = "позволить", wordId = 2}
                    }
                });

            _words.Add(
                new Word
                {
                    id = 3,
                    text = "feel",
                    Meanings = new List<WordMeaning> {
                                    new WordMeaning{id = 3, text = "чувствовать", wordId = 3}
                    }
                });

            _words.Add(
                new Word
                {
                    id = 4,
                    text = "have",
                    Meanings = new List<WordMeaning> {
                                    new WordMeaning{id = 4, text = "иметь", wordId = 4}
                    }
                });
        }
    }

}
