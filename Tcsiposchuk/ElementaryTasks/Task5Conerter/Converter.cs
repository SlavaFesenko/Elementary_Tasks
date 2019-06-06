using System;
using System.Collections.Generic;

namespace Task5Conerter
{
    public class Converter
    {
        #region Properties and Fields

        readonly string[] numbers1to15 = {"", "one", "two" , "three" , "four" , "five" , "six" , "seven",
        "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen","sixteen","seventeen" , "eighteen", "nineteen"};
        readonly string[] numbers20to90 = { "", "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eigthy", "ninety" };
        readonly string hundred = "hundred";
        readonly string thousand = "thousand";
        readonly string million = "million";
        public int Number { get; set; }
        public string String
        {
            get
            {
                return Number >= 0 ? ConvertNumberToString() : "minus " + ConvertNumberToString();
            }
        }

        #endregion

        #region Constructors

        public Converter(int number)
        {
            Number = number;
        }

        #endregion

        #region Methods

        private string ConvertNumberToString()
        {
            string result = "" ;
            List<int> digits = CreateListWithDigits(Number, FindNumberDigit(Number));
            switch(digits.Count)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result += GetForUnit(digits[0]);
                    break;
                case 2:
                    result += GetStringForDozens(digits[0], digits[1]);
                    break;
                case 3:
                    result += GetFor3Digits(digits);
                    break;
                case 4:
                    result += GetForUnit(digits[0]) + " " + thousand + " ";
                    digits.RemoveAt(0);
                    result += GetFor3Digits(digits);
                    break;
                case 5:
                    result += GetStringForDozens(digits[0],digits[1]) + " " + thousand + " ";
                    digits.RemoveRange(0, 2);
                    result += GetFor3Digits(digits);
                    break;
                case 6:
                    result = GetForHundredThousand(digits);
                    break;
                case 7:
                    result += GetForUnit(digits[0]) + " " + million + " ";
                    result += GetForHundredThousand(digits.GetRange(1, digits.Count - 1));
                    break;
                case 8:
                    result += GetStringForDozens(digits[0], digits[1]) + " " + million + " ";
                    result += GetForHundredThousand(digits.GetRange(2, digits.Count - 2));
                    break;
                case 9:
                    result += GetFor3Digits(digits.GetRange(0, 3)) + " " + million + " ";
                    result += GetForHundredThousand(digits.GetRange(3, digits.Count - 3));
                    break;
            }
            return result;

        }

        private string GetForHundredThousand(List<int> digits)
        {
            string result = "";
            result += GetFor3Digits(digits.GetRange(0, 3)) + " " + (digits[0] > 0 ? thousand + " " : " ");
            digits.RemoveRange(0, 3);
            result += GetFor3Digits(digits);
            return result;
        }

        private string GetForUnit(int digit)
        {
            return numbers1to15[digit];
        }
        private string GetFor3Digits(List<int> digits)
        {
            string result1 = numbers1to15[digits[0]] + " " + (digits[0] > 0 ?  hundred + " " : " ");
            result1 += GetStringForDozens(digits[1], digits[2]);
            return result1;
        }

        private string GetStringForDozens(params int[] digits)
        {
            string result="";

            switch (digits[0] * 10 + digits[1])
            {
                case 10:
                    result = numbers1to15[10];
                    break;
                case 11:
                    result =  numbers1to15[11];
                    break;
                case 12:
                    result =  numbers1to15[12];
                    break;
                case 13:
                    result = numbers1to15[13];
                    break;
                case 14:
                    result =  numbers1to15[14];
                    break;
                case 15:
                    result = numbers1to15[15];
                    break;
                case 16:
                    result = numbers1to15[16];
                    break;
                case 17:
                    result =  numbers1to15[17];
                    break;
                case 18:
                    result = numbers1to15[18];
                    break;
                case 19:
                    result = numbers1to15[19];
                    break;
                default:
                    result = numbers20to90[digits[0]] + (digits[1] > 0 ? "-" + numbers1to15[digits[1]] : " ");
                    break;
            }

            return result;
        }

        private static List<int> CreateListWithDigits(int number, int quantityDigitsInNumber)
        {
            List<int> arrayDigits = new List<int>();
            number = Math.Abs(number);

            string stringNumber = Convert.ToString(number);
            for (int digree = 0; digree < quantityDigitsInNumber; digree++)
            {
                arrayDigits.Add(Convert.ToInt32(stringNumber[digree] - '0'));
            }

            return arrayDigits;
        }

        private static int FindNumberDigit(int number)
        {
            int numberDigitInNumber = 0;

            number = Math.Abs(number);
            while (number >= 1)
            {
                number /= 10;
                numberDigitInNumber++;
            }

            return numberDigitInNumber;
        }

        #endregion

    }
}
