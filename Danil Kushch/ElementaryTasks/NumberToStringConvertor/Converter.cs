using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
{
    public static class Converter
    {
        #region Prvt Fields

        private static int _billion;
        private static int _million;
        private static int _thousand;
        private static int _hundred;

        #endregion

        #region Prvt Methods

        private static void SplitNumberByDigits(int number)
        {
            _billion = (number - (number % 1000000000))/ 1000000000;
            _million = ((number % 1000000000) - (number % 1000000)) / 1000000;
            _thousand = ((number % 1000000) - (number % 1000)) / 1000;
            _hundred = number % 1000;
        }

        private static string ConvertBillionToString()
        {
            if (_billion == 0)
                return string.Empty;
            else
                return $"{ConvertHundredToString(_billion)} billion";
        }

        private static string ConvertMillionToString()
        {
            if (_million == 0)
                return string.Empty;
            else
                return $"{ConvertHundredToString(_million)} million";
        }
        
        private static string ConvertThousandToString()
        {
            if (_thousand == 0)
                return string.Empty;
            else
                return $"{ConvertHundredToString(_thousand)} thousand";
        }

        private static string ConvertUnitToString(int number)
        {
            string result = string.Empty;

            switch (number)
            {
                case 0:
                    result = string.Empty;
                    break;
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;                   
            }
            
            return result;
        }

        private static string ConvertTenToString(int number)
        {
            string result = string.Empty;

            if (number > 9)
            {
                switch (number)
                {
                    case 10:
                        result = " ten";
                        break;
                    case 11:
                        result = " eleven";
                        break;
                    case 12:
                        result = " twelve";
                        break;
                    case 13:
                        result = " thirteen";
                        break;
                    default:
                        if (number < 20)
                            result = $"{ConvertUnitToString(number % 10)}teen";
                        else
                            result = ConvertMoreThanTwenty(number);
                        break;
                }
            }
            else
                result = ConvertUnitToString(number);

            return result;
        }

        private static string ConvertMoreThanTwenty(int number)
        {
            string result = string.Empty;

            int unit = number % 10;
            int ten = (number - (number % 10)) / 10;

            switch (ten)
            {               
                case 2:
                    result = $"twenty-{ConvertUnitToString(unit)}";
                    break;
                case 3:
                    result = $"thirty-{ConvertUnitToString(unit)}";
                    break;
                case 4:
                    result = $"fourty-{ConvertUnitToString(unit)}";
                    break;
                case 5:
                    result = $"fifty-{ConvertUnitToString(unit)}";
                    break;
                case 6:
                    result = $"sixty-{ConvertUnitToString(unit)}";
                    break;
                case 7:
                    result = $"seventy-{ConvertUnitToString(unit)}";
                    break;
                case 8:
                    result = $"eighty-{ConvertUnitToString(unit)}";
                    break;
                case 9:
                    result = $"ninety-{ConvertUnitToString(unit)}";
                    break;
            }

            return result.TrimEnd('-');
        }
                
        private static string ConvertHundredToString(int number)
        {
            int ten = number % 100;
            int hundred = (number - ten) / 100;

            if (hundred != 0)
                return  $"{ConvertUnitToString(hundred)} hundred {ConvertTenToString(ten)}";
            else
                return $"{ConvertTenToString(ten)}";
        }

        #endregion

        #region Pub Method

        public static string Convert(int number)
        {
            string result = string.Empty;

            if (number == 0)
                result = "zero";
            else
            {
                if (number > 0)
                {
                    SplitNumberByDigits(number);
                    result = $"{ConvertBillionToString()} {ConvertMillionToString()} {ConvertThousandToString()} {ConvertHundredToString(_hundred)}".TrimStart();
                }
                else
                {
                    number = -number;
                    SplitNumberByDigits(number);
                    result = $"{ConvertBillionToString()} {ConvertMillionToString()} {ConvertThousandToString()} {ConvertHundredToString(_hundred)}".TrimStart();
                    result = $"minus {result}";
                }
            }         
            
            return result;
        }

        #endregion
    }
}
