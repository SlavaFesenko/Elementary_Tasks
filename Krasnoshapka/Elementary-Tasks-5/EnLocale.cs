using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_5
{

    public class EnLocale : NumberToString
    {
        private readonly Dictionary<int, string> _units =
             new Dictionary<int, string>()
             {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
             };

        private readonly Dictionary<int, string> _firstTens =
             new Dictionary<int, string>()
             {
                { 0, "ten" },
                { 1, "eleven" },
                { 2, "twelve" },
                { 3, "thirteen" },
                { 4, "fourteen" },
                { 5, "fifteen" },
                { 6, "sixteen" },
                { 7, "seventeen" },
                { 8, "eighteen" },
                { 9, "nineteen" },
             };

        
        private readonly Dictionary<int, string> _tens =
             new Dictionary<int, string>()
             {
                { 2, "twenty" },
                { 3, "thirty" },
                { 4, "forty" },
                { 5, "fifty" },
                { 6, "sixty" },
                { 7, "seventy" },
                { 8, "eighty" },
                { 9, "ninety" },
             };

      
        private readonly Dictionary<int, string> _prefix =
             new Dictionary<int, string>()
             {
                { 1, string.Empty },
                { 2, "thousand" },
                { 3, "million" },
                { 4, "billion" },
             };

       
        protected override string ReturnFirstTens(int firstTens)
        {
            return _firstTens[firstTens];
        }

       
        protected override string ReturnHundreds(int hundred)
        {
            return _units[hundred] + " hundred";
        }

       
        protected override string ReturnNegativeSign()
        {
            return "minus";
        }

        
        protected override string ReturnPrefix(int rank, int unit)
        {
            return _prefix[rank];
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
            return _units[unit];
        }

        protected override string ReturnZero()
        {
            return "Zero!";
        }
    }
}
