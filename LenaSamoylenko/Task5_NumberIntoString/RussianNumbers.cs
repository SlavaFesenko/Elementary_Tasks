using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task5_NumberIntoString
{
   


class RussianNumbers : ICommonNumbers
{



       








    public bool ConcatMillionsAndSmallerExponents(int millions, StringBuilder smaller, out StringBuilder result)
    {
        throw new NotImplementedException();
    }

    public bool ConcatHundredsAndSmallerExponents(int hundreds, StringBuilder smaller, out StringBuilder result)
    {
        
    }

    public bool ConcatTensAndUnits(int tens, int units, out StringBuilder result)
    {
       
    }

    private StringBuilder ForConcatUnits(StringBuilder builder, int units)
    {
        builder.Append(numberParts[units]);
        builder.Append(EndForUnits[units]);

        return builder;
    }

    //not yet
    public bool ConcatThousandsAndSmallerExponents(int thousand, StringBuilder smaller, out StringBuilder result)
    {
        bool forOut = false;
        result = null;
        StringBuilder builder;

        try
        {
            builder = new StringBuilder();

            //change to common version
            int thousandDiviteOnTenReminder = thousand % 10;
            int thousandDiviteOnTen = thousand / 10;
            int thousandDiviteOnHundred = thousand / 100;


            if (thousandDiviteOnTenReminder == 0)
            {
                ConcatTensAndUnits(thousandDiviteOnTen, 0, out builder);
                ConcatHundredsAndSmallerExponents(thousandDiviteOnHundred, builder, out result);
            }
            else
            {

                result = builder;
            }



            forOut = true;
        }
        catch (Exception exeption)
        {
            //add to log file

        }

        return forOut;
    }
}
}
