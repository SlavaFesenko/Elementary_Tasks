using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NumberToStringConvertor
{
    public static class Converter
    {
        #region Prvt Fields

        private static int _billion;
        private static int _million;
        private static int _thousand;
        private static int _hundred;
        private static Logger _log  = LogManager.GetCurrentClassLogger();

        #endregion

        #region Prvt Methods

        /// <summary>
        /// Return result of convertation
        /// </summary>
        /// <returns>Converted number to string</returns>
        private static string ReturnResultingString()
        {
            return $"{ConvertBillionToString()} {ConvertMillionToString()} {ConvertThousandToString()} {ConvertHundredToString(_hundred)}".TrimStart();
        }

        /// <summary>
        /// Split number by digits
        /// </summary>
        /// <param name="number">Number to splitting</param>
        private static void SplitNumberByDigits(int number)
        {
            _billion = (number - (number % 1000000000))/ 1000000000;
            _million = ((number % 1000000000) - (number % 1000000)) / 1000000;
            _thousand = ((number % 1000000) - (number % 1000)) / 1000;
            _hundred = number % 1000;
            _log.Trace($"The number {number} was splitted.");
        }

        private static string ConvertBillionToString()
        {
            if (_billion == 0)
            {
                _log.Trace("The billion digit was equal zero.");

                return string.Empty;
            }
            else
            {
                _log.Trace($"The billion digit({_billion}) was converted.");

                return $"{ConvertHundredToString(_billion)} billion";
            }
        }

        private static string ConvertMillionToString()
        {
            if (_million == 0)
            {
                _log.Trace("The million digit was equal zero.");

                return string.Empty;
            }
            else
            {
                _log.Trace($"The million digit({_million}) was converted.");

                return $"{ConvertHundredToString(_million)} million";
            }
        }
        
        private static string ConvertThousandToString()
        {
            if (_thousand == 0)
            {
                _log.Trace("The thousand digit was equal zero.");

                return string.Empty;
            }
            else
            {
                _log.Trace($"The thousand digit({_thousand}) was converted.");

                return $"{ConvertHundredToString(_thousand)} thousand";
            }
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
            _log.Trace($"Unit digit({number}) was converted.");

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
            _log.Trace($"The ten digit({number}) was converted.");

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
            _log.Trace($"The ten digit({number}) was converted.");

            return result.TrimEnd('-');
        }
                
        private static string ConvertHundredToString(int number)
        {
            int ten = number % 100;
            int hundred = (number - ten) / 100;

            if (hundred != 0)
            {
                _log.Trace("The hundred digit was equal 0.");

                return $"{ConvertUnitToString(hundred)} hundred {ConvertTenToString(ten)}";
            }
            else
            {
                _log.Trace($"The hundred digit({_hundred}) was converted.");

                return $"{ConvertTenToString(ten)}";
            }
        }

        #endregion

        #region Pub Method

        /// <summary>
        /// Convert number to string
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>String after convertation</returns>
        public static string Convert(int number)
        {
            string result = string.Empty;

            if (number == 0)
            {
                result = "zero";
                _log.Trace("Number was equal zero.");
            }
            else
            {
                if (number > 0)
                {
                    SplitNumberByDigits(number);
                    result = ReturnResultingString();
                    _log.Trace($"Number {number} was converted.");
                }
                else
                {
                    number = -number;
                    SplitNumberByDigits(number);
                    result = ReturnResultingString();
                    result = $"minus {result}";
                    _log.Trace($"Number {number} and was converted.");
                }
            }         
            
            return result.TrimEnd();
        }

        #endregion
    }
}
