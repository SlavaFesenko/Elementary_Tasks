using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_3
{
    class Validator
    {
        public static bool ValidSides(float firstSide, float secondSide, float thirdSide)
        {
            return firstSide > 0 
                && secondSide > 0 
                && thirdSide > 0
                && (firstSide + secondSide > thirdSide)
                && (firstSide + thirdSide > secondSide)
                && (secondSide + thirdSide > firstSide);
        }
    }
}
