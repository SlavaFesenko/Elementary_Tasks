using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task5_NumberIntoString
{
    internal class GetHundreds : ForConcatNumbers, ICommonNumbers
    {

        #region fields
        private static readonly string commonEndHundreds = "сот";
        private StringBuilder tensAndUnits;
        private ForConcatNumbers baseNumbers;
        private Dictionary<int, string> ForHundreds;
        #endregion

        #region Constructors
        public GetHundreds(StringBuilder tensAndUnits)
        {
            try
            {
                this.tensAndUnits = tensAndUnits;
                baseNumbers = new ForConcatNumbers();

                ForHundreds = new Dictionary<int, string>
                {
                    [1] = "сто",
                    [2] = String.Concat(baseNumbers[2], "ести"),
                    [3] = String.Concat(baseNumbers[3], "ста"),
                    [4] = String.Concat(baseNumbers[4], "еста"),
                    [5] = String.Concat(baseNumbers[5], commonEndHundreds),
                    [6] = String.Concat(baseNumbers[6], commonEndHundreds),
                    [7] = String.Concat(baseNumbers[7], commonEndHundreds),
                    [8] = String.Concat(baseNumbers[8], commonEndHundreds),
                    [9] = String.Concat(baseNumbers[9], commonEndHundreds)
                };
            }
            catch
            {
                //add to log file
            }
        }
        #endregion

        #region Indexers
        /// <summary>
        /// Use index to choose how would be look hundreds 
        /// </summary>
        /// <param name="number">Choose from "0" to "9" for get string number`s root</param>
        /// <returns>text</returns>
        public string this[int number] { get => ForHundreds[number]; private set => ForHundreds[number] = value; }
        #endregion

        #region Methods
        public bool IsConcatBiggerAndSmallerExponents(int hundreds, out StringBuilder hundredsAndOthers)
        {
            bool forOut = false;
            hundredsAndOthers = null;
            StringBuilder builder;

            try
            {
                builder = new StringBuilder();

                if (hundreds == 1 && tensAndUnits == null)
                {
                    builder.Append(ForHundreds[hundreds]);
                }
                else if (hundreds == 0)
                {
                    builder = tensAndUnits;
                }
                else
                {
                    builder.Append(ForHundreds[hundreds]);
                    builder.Append(Path.PathSeparator); //TODO: its not PROBEL
                    builder.Append(tensAndUnits);
                }

                hundredsAndOthers = builder;
                forOut = true;
            }
            catch (Exception exeption)
            {
                //add to log file

            }

            return forOut;
        }
        #endregion

    }
}
