using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    public class Validator
    {
        public static bool IsCorrectRange(int lowLimit, int upLimit)
        {
            if (lowLimit < upLimit)
                return true;

            return false;
        }

        public static bool IsCorrectArgs8Task(string[] args, out int[] paramsTask8)
        {
            paramsTask8 = Array.ConvertAll(args, int.Parse);
            if (paramsTask8[0] == 8 && paramsTask8[1] < paramsTask8[2])
                return true;

            return false;
        }
    }
}
