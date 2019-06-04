using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_NumberIntoString
{
    internal class GetUnits : ForConcatNumbers, ICommonNumbers
    {
        #region Fields

        private static string commonEndUnit = "ь";
        private ForConcatNumbers baseNumbers;
        private Dictionary<int, string> ForUnits;

        #endregion

        #region Constructors

        public GetUnits()
        {
            try
            {
                baseNumbers = new ForConcatNumbers();
                ForUnits = new Dictionary<int, string>
                {
                    [0] = null,
                    [1] = "н",
                    [2] = "a",
                    [3] = null,
                    [4] = "e",
                    [5] = commonEndUnit,
                    [6] = commonEndUnit,
                    [7] = commonEndUnit,
                    [8] = commonEndUnit,
                    [9] = commonEndUnit
                };
            }
            catch (Exception)
            {
                //add to log file
            }

        }

        #endregion

        #region Indexer

        public string this[int number] { get => ForUnits[number]; private set => ForUnits[number] = value; }

        #endregion

        #region Methods

        public bool IsConcatBiggerAndSmallerExponents(int units, out StringBuilder unitsInNumber)
        {
            bool result = false;
            StringBuilder builder = null;
            unitsInNumber = null;

            try
            {
                builder = new StringBuilder();
                builder.Append(baseNumbers[units]);
                builder.Append(ForUnits[units]);

                unitsInNumber = builder;

            }
            catch (Exception)
            {
                //add to log file

            }

            return result;
        }

        #endregion

    }
}
