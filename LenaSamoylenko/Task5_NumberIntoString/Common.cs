using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_NumberIntoString
{
    public static class Common
    {
        public static int GetHundreds(int thousands, out int forCountTens, out int forCountUnits)
        {
            int forCountHundreds = 0;

            forCountHundreds = thousands / 100;
            forCountTens = (thousands - forCountHundreds * 100) / 10;
            forCountUnits = (thousands - forCountTens * 10);

            return forCountHundreds;
        }


        public static StringBuilder GetBuilderIfUnitsAndTensZero(int forCountHundreds, ICommonNumbers indexer)
        {
            StringBuilder builder = null;

            GetHundreds getHundreds = new GetHundreds(null);
            builder = CommonPartForTensAndUnits(getHundreds, forCountHundreds, indexer);

            return builder;
        }

        internal static StringBuilder CommonPartForTensAndUnits(GetHundreds getHundreds, int forCountHundreds, ICommonNumbers indexer)
        {
            StringBuilder builder = null;

            getHundreds.IsConcatBiggerAndSmallerExponents(forCountHundreds, out builder);
            builder.Append(indexer[0]);

            return builder;
        }
    }
}