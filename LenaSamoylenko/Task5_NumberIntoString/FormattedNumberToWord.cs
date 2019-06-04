using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task5_NumberIntoString
{
    class FormattedNumberToWord : IFormattable
    {
        private int number;

        private int units;
        private int tens;
        private int hundreds;
        private int thousands;
        private int millions;

        private string numberName;

        const int UNIT = 10;

        public Dictionary<string, int> Digits = new Dictionary<string, int>
        {
            ["Units"] = 0,
            ["Tens"] = 1,
            ["Hundreds"] = 2,
            ["Thousands"] = 3,
            ["Millions"] = 6
        };

        public global::System.String NumberName { get => numberName; set => numberName = value; }

        public FormattedNumberToWord(int number)
        {
            this.number = number;
            this.ConvertIntoSimpleParth();
        }


        private void ConvertIntoSimpleParth()
        {

            int _forUnits = (int)Math.Pow(UNIT, Digits[@"Units"]);
            int _forTens = (int)Math.Pow(UNIT, Digits[@"Tens"]);
            int _forHundreds = (int)Math.Pow(UNIT, Digits[@"Hundreds"]);
            int _forThousands = (int)Math.Pow(UNIT, Digits[@"Thousands"]);
            int _forMillions = (int)Math.Pow(UNIT, Digits["Millions"]);

            millions = number / _forMillions;
            thousands = (millions * _forMillions) / _forThousands;
            hundreds = (number - millions * _forMillions - thousands * _forThousands) / _forHundreds;
            tens = (number - millions * _forMillions - thousands * _forThousands - hundreds * _forHundreds) / _forTens;
            units = number - millions * _forMillions - thousands * _forThousands - hundreds * _forHundreds - tens * _forTens;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string result = null;

            if (String.IsNullOrEmpty(format) == true) format = "RUS";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentUICulture;

            switch (format.ToUpperInvariant())
            {
                case "RUS": return result = "some data";
                case "ENG": return result = "somedata";

                default:
                    //change
                    throw new FormatException(String.Format("Format {0} isnt supported", format));


            }


        }

        //private void ToDigitsOfNumber

    }
}
