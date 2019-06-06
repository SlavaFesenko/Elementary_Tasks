using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTask5
{
    public abstract class NumberToString
    {
      
        private const int MAX_VALUE = 2100000000;

       
        public string Convert(int number)
        {
            StringBuilder result = new StringBuilder();
            IsNegative(number, result);
            number = Math.Abs(number);
            if (number > MAX_VALUE)
            {
                throw new OverflowException("The number modulus must be in the range of 2100000000!");
            }

            int rank = GetRank(number);
            int remain;
            while (rank != 0)
            {
                result.Append(GetRankString(number, rank));
                rank--;
                remain = number % (int)OptimizedMathFunctions.Pow(1000, (uint)rank);
                number = remain;
            }

            if (result.ToString() == string.Empty)
            {
                result.Append(ReturnZero() + " ");
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

       
        private void IsNegative(int number, StringBuilder result)
        {
            if (number < 0)
            {
                result.Append(ReturnNegativeSign() + " ");
            }
        }

      
        private static int GetRank(int number)
        {
            int i = 0;
            for (; number != 0; i++)
            {
                number /= 1000;
            }
            return i;
        }
       
        private string GetRankString(int number, int rank)
        {
            StringBuilder result = new StringBuilder(100);
            int threeDigitAreaNumber;
            int hundred;
            threeDigitAreaNumber = number / (int)OptimizedMathFunctions.Pow(1000, (uint)rank - 1);

            hundred = threeDigitAreaNumber / 100;
            if (hundred != 0)
            {
                result.Append(ReturnHundreds(hundred) + " ");
            }

            if ((threeDigitAreaNumber % 100 / 10) != 1)
            {
                int tens;
                tens = threeDigitAreaNumber / 10 % 10;
                if (tens != 0)
                {
                    result.Append(ReturnTens(tens) + " ");
                }

                if (rank != 2)
                {
                    if (threeDigitAreaNumber % 10 != 0)
                    {
                        result.Append(ReturnUnits(threeDigitAreaNumber % 10) + " ");
                    }
                }
                else
                {
                    if (threeDigitAreaNumber % 10 != 0)
                    {
                        result.Append(ReturnUnitsForThousands(threeDigitAreaNumber % 10) + " ");
                    }
                }
                if (result.ToString() != string.Empty && rank != 1)
                {
                    result.Append(ReturnPrefix(rank, threeDigitAreaNumber % 10) + " ");
                }
            }
            else
            {
                result.Append(ReturnFirstTens(threeDigitAreaNumber % 10) + " ");
                if (rank != 1)
                {
                    result.Append(ReturnPrefix(rank, 7) + " ");
                }
            }

            return result.ToString();
        }

      
        protected abstract string ReturnZero();
        protected abstract string ReturnHundreds(int hundred);  
        protected abstract string ReturnFirstTens(int firstTens);
        protected abstract string ReturnTens(int tens);
        protected abstract string ReturnUnits(int unit);
        protected abstract string ReturnUnitsForThousands(int unit);
        protected abstract string ReturnPrefix(int rank, int unit);
        protected abstract string ReturnNegativeSign();
    }
}
