using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTasks8
{
    class Validator
    {
        public static bool ValidFibonacci(int leftBorder, int rightBorder)
        {
            bool result = false;
            if ((leftBorder > 0 && rightBorder > 0) && (leftBorder < rightBorder))
            {
                result = true;
            }
            return result;
        }

        public static bool ValidSquare(int rightBorder)
        {
            bool result = false;
            if (rightBorder > 1)
            {
                result = true;
            }
            return result;
        }


    }
}
