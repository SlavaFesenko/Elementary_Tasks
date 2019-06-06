using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_5
{

    public class RuLocale : NumberToString
    {
      
        private const int ONE = 1;
        private const int TWO = 2;

        private readonly Dictionary<int, string> _units =
             new Dictionary<int, string>()
             {
                { 1, "один" },
                { 2, "два" },
                { 3, "три" },
                { 4, "четыре" },
                { 5, "пять" },
                { 6, "шесть" },
                { 7, "семь" },
                { 8, "восемь" },
                { 9, "девять" },
             };

 
        private readonly Dictionary<int, string> _firstTens =
             new Dictionary<int, string>()
             {
                { 0, "десять" },
                { 1, "одиннадцать" },
                { 2, "двенадцать" },
                { 3, "тринадцать" },
                { 4, "четырнадцать" },
                { 5, "пятнадцать" },
                { 6, "шестнадцать" },
                { 7, "семнадцать" },
                { 8, "восемнадцать" },
                { 9, "девятнадцать" },
             };

      
        private readonly Dictionary<int, string> _tens =
             new Dictionary<int, string>()
             {
                { 0, string.Empty },
                { 2, "двадцать" },
                { 3, "тридцать" },
                { 4, "сорок" },
                { 5, "пятьдесят" },
                { 6, "шестьдесят" },
                { 7, "семьдесят" },
                { 8, "восемьдесят" },
                { 9, "девяносто" },
             };

     
        private readonly Dictionary<int, string> _hundreds =
             new Dictionary<int, string>()
             {
                { 1, "сто" },
                { 2, "двести" },
                { 3, "триста" },
                { 4, "четыреста" },
                { 5, "пятьсот" },
                { 6, "шестьсот" },
                { 7, "семьсот" },
                { 8, "восемьсот" },
                { 9, "девятьсот" },
             };

    
        private readonly Dictionary<int, string> _prefix =
             new Dictionary<int, string>()
             {
                { 1, string.Empty },
                { 2, "тысяч" },
                { 3, "миллион" },
                { 4, "миллиард" },
             };

   
        protected override string ReturnFirstTens(int firstTens)
        {
            return _firstTens[firstTens];
        }

       
        protected override string ReturnHundreds(int hundred)
        {
            return _hundreds[hundred];
        }

      
        protected override string ReturnNegativeSign()
        {
            return "минус";
        }

     
        protected override string ReturnPrefix(int rank, int unit)
        {
            string result = string.Empty;
            switch (rank)
            {
                case ONE:
                    break;
                case TWO:
                    if (unit == 1)
                    {
                        result = _prefix[rank] + "а";
                    }
                    else if (unit < 5 && unit > 0)
                    {
                        result = _prefix[rank] + "и";
                    }
                    else
                    {
                        result = _prefix[rank];
                    }

                    break;
                default:
                    if (unit < 5 && unit > 1)
                    {
                        result = _prefix[rank] + "а";
                    }
                    else if (unit >= 5)
                    {
                        result = _prefix[rank] + "ов";
                    }
                    else
                    {
                        result = _prefix[rank];
                    }

                    break;
            }

            return result;
        }

        protected override string ReturnTens(int tens)
        {
            return _tens[tens];
        }

      
        protected override string ReturnUnits(int unit)
        {
            return _units[unit];
        }

        protected override string ReturnUnitsForThousands(int unit)
        {
            string result = string.Empty;
            switch (unit)
            {
                case ONE:
                    result = "одна";
                    break;
                case TWO:
                    result = "две";
                    break;
                default:
                    result = _units[unit];
                    break;
            }

            return result;
        }

   
        protected override string ReturnZero()
        {
            return "Ноль!";
        }
    }
}
