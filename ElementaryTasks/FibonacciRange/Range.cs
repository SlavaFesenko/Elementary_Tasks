using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRange
{
    public class Range
    {
        #region Prvt Fields

        private int _begin;
        private int _end;

        #endregion

        #region Ctor

        public Range(int begin, int end)
        {
            _begin = begin;
            _end = end;
        }

        #endregion

        #region Methods

        private int ReturnFibonacciNumber(int n)
        {
            if (n == 0)
                return 0;   
            if (n == 1)
                return 1;

            return ReturnFibonacciNumber(n - 1) + ReturnFibonacciNumber(n - 2);
        }

        public string ShowRange()
        {
            string result = string.Empty;
            for (int i = _begin; ReturnFibonacciNumber(i) <= _end; i++)
            {
                result += $"{ReturnFibonacciNumber(i)},";
            }

            if (result == string.Empty)
                result = "Empty range!";

            return result.TrimEnd(',');
        }

        #endregion

    }
}
