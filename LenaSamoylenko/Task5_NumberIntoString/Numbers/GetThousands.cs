using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_NumberIntoString
{
    class GetThousands : ForConcatNumbers, ICommonNumbers
    {
        #region fields

        private static readonly string commonEndThousands = "тысяч";
        private StringBuilder hundredsAndOthers;
        private ForConcatNumbers baseNumbers;
        private Dictionary<int, string> ForThousands;

        #endregion

        #region Constructors
        public GetThousands(StringBuilder hundredsAndOthers)
        {
            try
            {
                this.hundredsAndOthers = hundredsAndOthers;
                baseNumbers = new ForConcatNumbers();

                ForThousands = new Dictionary<int, string>
                {
                    [0] = commonEndThousands,
                    [1] = String.Concat(commonEndThousands, "а"),
                    [2] = String.Concat(commonEndThousands, "и"),
                    [3] = String.Concat(commonEndThousands, "и"),
                    [4] = String.Concat(commonEndThousands, "и"),
                    [5] = commonEndThousands,
                    [6] = commonEndThousands,
                    [7] = commonEndThousands,
                    [8] = commonEndThousands,
                    [9] = commonEndThousands
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
        public string this[int number] { get => ForThousands[number]; private set => ForThousands[number] = value; }
        #endregion

        #region Methods


        public bool IsConcatBiggerAndSmallerExponents(int thousands, out StringBuilder thouthandsAndOthers)
        {
            bool forOut = false;

            StringBuilder builder;
            thouthandsAndOthers = null;

            int forCountHundreds = 0;
            int forCountTens = 0;
            int forCountUnits = 0;

            GetHundreds getHundreds = null;
            GetTens getTens = null;
            GetUnits getUnits = null;

            forCountHundreds = Common.GetHundreds(thousands, out forCountTens, out forCountUnits);

            try
            {
                builder = new StringBuilder();

                if (forCountTens == 0 && forCountUnits == 0)
                {
                    getHundreds = new GetHundreds(null);
                    builder = CommonPartForTensAndUnits(getHundreds, forCountHundreds);
                }
                else if (forCountUnits == 0)
                {
                    getTens = new GetTens(null, 0);
                    getTens.IsConcatBiggerAndSmallerExponents(forCountTens, out builder);

                    getHundreds = new GetHundreds(builder);
                    builder = CommonPartForTensAndUnits(getHundreds, forCountHundreds);
                }
                else
                {
                    StringBuilder helperBuilder = new StringBuilder();

                    //get units into builder conteiner
                    getUnits = new GetUnits();
                    getUnits.IsConcatBiggerAndSmallerExponents(forCountUnits, out builder);

                    //if units ==2 we should change ending
                    if (forCountUnits == 2)
                    {
                        helperBuilder.Replace('а', 'е');
                    }

                    //found tens and units into helpbuilder
                    getTens = new GetTens(helperBuilder, forCountUnits);
                    getTens.IsConcatBiggerAndSmallerExponents(forCountTens, out helperBuilder);

                    //set builder=0 for using in next counting
                    builder = null;

                    //get hundreds and smaller parts into builder
                    getHundreds = new GetHundreds(helperBuilder);
                    getHundreds.IsConcatBiggerAndSmallerExponents(forCountHundreds, out builder);

                    //add ending to indetify part like thouthands 
                    builder.Append(commonEndThousands);
                    builder.Append(ForThousands[forCountUnits]);
                }

                thouthandsAndOthers = builder;
                forOut = true;
            }
            catch (Exception exception)
            {
                //add to log file
            }

            return forOut;
        }

        private StringBuilder CommonPartForTensAndUnits(GetHundreds getHundreds, int forCountHundreds)
        {
            StringBuilder builder = null;

            getHundreds.IsConcatBiggerAndSmallerExponents(forCountHundreds, out builder);
            builder.Append(ForThousands[0]);

            return builder;
        }

        #endregion

    }
}
