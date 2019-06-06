using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Numbers
{
    public  class WordsGenerator
    {
        private  int[] _number;
        private  int _digits;
        private string[] _words;

        #region Constructor

        public WordsGenerator(int number)
        {
            _digits = GetCountDigits(number);
            _number = new int[_digits];
            _words = new string[_digits];

            GetNumerics(number);
        }

        #endregion

        #region Methods

        

        public string[] GetWords()
        {
            for (int i = 0; i < _number.Length; i++)
            {
                _words[i] = Enum.GetName(typeof(Unit), _number[i]);
            }

            return _words;
        }

        private void GetNumerics(int number)
        {
            for (int i = 0; i < _number.Length; i++)
            {
                _number[i] = number % 10;
                number /= 10;
            }

            Array.Reverse(_number);
        }

        private int GetCountDigits(int number)
        {
            int digits = 0;

            if (number / 10 > 0)
            {
                while (number > 0)
                {
                    number /= 10;
                    digits++;
                }
            }
            else
            {
                digits = 1;
            }

            return digits;
        } 

        #endregion
    }
}
