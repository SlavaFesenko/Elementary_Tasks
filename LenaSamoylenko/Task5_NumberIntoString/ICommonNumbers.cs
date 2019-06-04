using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_NumberIntoString
{
    public interface ICommonNumbers
    {

        string this[int number] { get; }

        bool IsConcatBiggerAndSmallerExponents(int biggerPart, out StringBuilder result);

    }

    internal class ForConcatNumbers
    {
        public string this[int number] { get => numberParts[number]; private set => numberParts[number] = value; }
        private string[] numberParts =
            { "ноль", "оди", "дв", "три", "четыр", "пят", "шест", "сем", "восем", "девят" };
    }

    class GetMillions : ForConcatNumbers, ICommonNumbers
    {
        #region Fields

        private static readonly string commonEndMillions = "миллион";
        private string ending1 = "а";
        private string ending2 = "ов";

        private StringBuilder thouthandsAndOthers;
        private ForConcatNumbers baseNumbers;
        private Dictionary<int, string> ForMillions;

        #endregion

        #region Constructors

        public GetMillions(StringBuilder thouthandsAndOthers)
        {
            try
            {
                this.thouthandsAndOthers = thouthandsAndOthers;
                baseNumbers = new ForConcatNumbers();

                ForMillions = new Dictionary<int, string>
                {
                    [0] = commonEndMillions,
                    [1] = commonEndMillions,
                    [2] = String.Concat(commonEndMillions, ending1),
                    [3] = String.Concat(commonEndMillions, ending1),
                    [4] = String.Concat(commonEndMillions, ending1),
                    [5] = String.Concat(commonEndMillions, ending2),
                    [6] = String.Concat(commonEndMillions, ending2),
                    [7] = String.Concat(commonEndMillions, ending2),
                    [8] = String.Concat(commonEndMillions, ending2),
                    [9] = String.Concat(commonEndMillions, ending2),
                };
            }
            catch
            {
                //add to log file
            }
        }

        #endregion

        #region Indexer

        public string this[int number] { get => ForMillions[number]; private set => ForMillions[number] = value; }

        #endregion

        #region Methods

        public bool IsConcatBiggerAndSmallerExponents(int millions, out StringBuilder millionsAndOther)
        {
            bool forOut = false;

            StringBuilder builder;
            millionsAndOther = null;

            int forCountHundreds = 0;
            int forCountTens = 0;
            int forCountUnits = 0;

            GetHundreds getHundreds = null;
            GetTens getTens = null;
            GetUnits getUnits = null;

            forCountHundreds = Common.GetHundreds(millions, out forCountTens, out forCountUnits);

            try
            {
                if (forCountTens == 0 && forCountUnits == 0)
                {
                    builder = Common.GetBuilderIfUnitsAndTensZero(forCountHundreds, this);
                }
                else if (forCountUnits == 0)
                {
                    //should change
                    getTens = new GetTens(null, 0);
                    getTens.IsConcatBiggerAndSmallerExponents(forCountTens, out builder);

                    getHundreds = new GetHundreds(builder);
                    builder = Common.CommonPartForTensAndUnits(getHundreds, forCountHundreds, this);
                }

            }
            catch (Exception exception)
            {

                throw;
            }

            return forOut;
        }

        #endregion

    }
}
