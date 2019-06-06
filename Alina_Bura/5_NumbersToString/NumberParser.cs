 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToString_5
{
    class NumberParser
    {
        private readonly Dictionary<int, string> _dictionary = new Dictionary<int, string>();

        public NumberParser(Dictionary<int, string> d)
        {
            _dictionary = d;
        }

        public string ToString(int number)
        {
            string numStr = number.ToString();
            int digitsCount = numStr.Length;
            int[] digits = numStr.ToCharArray().Select(n => n - '0').ToArray();
            
            string result = string.Empty;
            string hundred = string.Empty;
            string thousand = string.Empty;

            switch (digitsCount)
            {
                case 1:
                case 7:
                    result = _dictionary[number];
                    break;
                case 2:
                    result = GetForTwo(digits, 0, 1);
                    break;
                case 3:
                    hundred = GetForOne(digits, 0, 100);
                    result = $"{hundred} {GetForTwo(digits, 1, 2)}";
                    break;
                case 4:
                    thousand = GetForOne(digits, 0, 1000);
                    hundred = GetForOneWithZeroCheck(digits, 1, 100);
                    result = $"{thousand} {hundred} {GetForTwo(digits, 2, 3)}";
                    break;
                case 5:
                    thousand = _dictionary[1000];
                    hundred = GetForOneWithZeroCheck(digits, 2, 100);
                    result = $"{GetForTwo(digits, 0, 1)} {thousand} {hundred} {GetForTwo(digits, 3, 4)}";
                    break;
                case 6:
                    thousand = _dictionary[1000];
                    hundred = GetForOneWithZeroCheck(digits, 3, 100);
                    result = $"{GetForOne(digits, 0, 100)} {GetForTwo(digits, 1, 2)} {thousand} {hundred} {GetForTwo(digits, 4, 5)}";
                    break;
                default:
                    break;
            }

            return result.Replace("  ", " ");
        }

        private string GetForOne(int[] digits, int index, int num)
        {
            return $"{_dictionary[digits[index]]} {_dictionary[num]}";
        }

        private string GetForOneWithZeroCheck(int[] digits, int index, int num)
        {
            string result;
            if (digits[index] != 0)
            {
                result = $"{_dictionary[digits[index]]} {_dictionary[num]}";
            }
            else
            {
                result = string.Empty;
            }

            return result;
        }
                
        private string GetForTwo(int[] digits, int i, int j)
        {
            string result;

            if (digits[i] == 0)
            {
                result = string.Empty;
            }
            if (digits[j] == 0)
            {
                result = $"{_dictionary[digits[i] * 10]}"; 
            }
            else
            {
                if (digits[i] * 10 + digits[j] < 20)
                {
                    result = _dictionary[digits[i] * 10 + digits[j]];
                }
                else
                {
                    result = $"{_dictionary[digits[i] * 10]} {_dictionary[digits[j]]}";
                }
            }
            return result;
        }
    }
}
