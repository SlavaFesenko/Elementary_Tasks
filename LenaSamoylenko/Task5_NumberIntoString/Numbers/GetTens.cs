using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_NumberIntoString
{
    internal class GetTens : ForConcatNumbers, ICommonNumbers
    {
        #region fields
        private static readonly string commonEndTens = "десят";
        private StringBuilder units;
        private int unitsInt;
        private ForConcatNumbers baseNumbers;
        private Dictionary<int, string> ForTens;
        #endregion

        #region Constructors
        public GetTens(StringBuilder units, int unitsInt)
        {
            try
            {
                this.units = units;
                this.unitsInt = unitsInt;
                baseNumbers = new ForConcatNumbers();

                ForTens = new Dictionary<int, string>
                {
                    [0] = "десять",
                    [1] = "надцать",
                    [2] = String.Concat(baseNumbers[2], "адцать"),
                    [3] = String.Concat(baseNumbers[3], "дцать"),
                    [4] = "сорок",
                    [5] = String.Concat(baseNumbers[5], commonEndTens),
                    [6] = String.Concat(baseNumbers[6], commonEndTens),
                    [7] = String.Concat(baseNumbers[7], commonEndTens),
                    [8] = String.Concat(baseNumbers[8], commonEndTens),
                    [9] = String.Concat(baseNumbers[9].Remove(baseNumbers[9].Length - 1), commonEndTens),
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
        /// Use index to choose root or end of simple number
        /// </summary>
        /// <param name="number">Choose from "0" to "9" for get string number`s root</param>
        /// <returns>text</returns>
        public string this[int number] { get => ForTens[number]; private set => ForTens[number] = value; }
        #endregion

        #region Methods

        /// <summary>
        /// Concat tens with units
        /// </summary>
        /// <param name="tens">how much tens got currunt number</param>
        /// <param name="tensWithUnits">parameters for next methods</param>
        /// <returns></returns>
        public bool IsConcatBiggerAndSmallerExponents(int tens, out StringBuilder tensWithUnits)
        {
            bool IsTrue = false;

            if (tens == 1)
            {
                IsTrue = IsConcatWithoutTens(tens, out tensWithUnits);
            }
            else
            {
                IsTrue = IsConcatWithTens(tens, out tensWithUnits);
            }

            return IsTrue;
        }

        /// <summary>
        /// from "0" to "9" or "20" to "99"
        /// </summary>
        /// <param name="tens"></param>
        /// <param name="tensAndUnits"></param>
        /// <returns></returns>
        private bool IsConcatWithoutTens(int tens, out StringBuilder tensAndUnits)
        {
            bool forOut = false;
            tensAndUnits = null;
            StringBuilder builder;

            try
            {
                builder = new StringBuilder();

                if (tens == 0)
                {
                    builder.Append(units);
                }
                else
                {
                    builder.Append(ForTens[tens]);
                    builder.Append(units);
                }

                tensAndUnits = builder;

                forOut = true;
            }
            catch (Exception exeption)
            {
                //add to log file

            }

            return forOut;
        }

        /// <summary>
        /// For numbers from 10 to 19
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tensAndUnits"></param>
        /// <returns></returns>
        private bool IsConcatWithTens(int tens, out StringBuilder tensAndUnits)
        {
            bool forOut = false;
            tensAndUnits = null;
            StringBuilder builder;

            try
            {
                builder = new StringBuilder();
                if (units.ToString() == baseNumbers[0])
                {
                    builder.Append(ForTens[0]);
                }
                else
                {
                    if (unitsInt==2)
                    {
                        units.Replace('a', 'е');
                    }
                    builder.Append(baseNumbers[unitsInt]);
                    builder.Append(ForTens[tens]);
                }

                tensAndUnits = builder;

                forOut = true;
            }
            catch (Exception)
            {
                //add to log

            }

            return forOut;
        }
        #endregion
    }
}
