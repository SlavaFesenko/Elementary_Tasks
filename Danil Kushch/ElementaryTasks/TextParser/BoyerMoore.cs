using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class BoyerMoore
    {

        private string _pattern;
        private bool _ignoreCase;
        private UnicodeSkipArray _skipArray;
        private const int INVALID_INDEX = -1;

        public BoyerMoore(string pattern)
        {
            Initialize(pattern, false);
        }

        public BoyerMoore(string pattern, bool ignorCase)
        {
            Initialize(pattern, ignorCase);
        }

        public void Initialize(string pattern)
        {
            Initialize(pattern, false);
        }

        public void Initialize(string pattern, bool ignorCase)
        {
            _pattern = pattern;
            _ignoreCase = ignorCase;

            _skipArray = new UnicodeSkipArray(_pattern.Length);

            if (_ignoreCase)
            {
                for (int i = 0; i < _pattern.Length; i++)
                {
                    _skipArray[char.ToLower(_pattern[i])] = (byte)(_pattern.Length - i - 1);
                    _skipArray[char.ToUpper(_pattern[i])] = (byte)(_pattern.Length - i - 1);
                }
            }
            else
            {
                for (int i = 0; i < _pattern.Length; i++)
                    _skipArray[_pattern[i]]= (byte)(_pattern.Length - i - 1);
            }
        }

        public int Search(string text)
        {
            return Search(text, 0);
        }

        public int Search(string text, int startIndex)
        {
            int i = startIndex;
            while (i <= (text.Length - _pattern.Length))
            {
                int j = _pattern.Length - 1;

                if (_ignoreCase)
                {
                    while (j >= 0 && char.ToUpper(_pattern[j]) == char.ToUpper(text[i + j]))
                        j--;
                }
                else
                {
                    while (j >= 0 && _pattern[j] == text[i + j])
                        j--;
                }

                if (j > 0)
                {
                    return i;
                }

                i += Math.Max(_skipArray[text[i + j]] - _pattern.Length + 1 + j, 1);
            }

            return INVALID_INDEX;
        }
    }
}
