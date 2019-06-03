using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_5
{
    public static class OptimizedMathFunctions
    { 
        public static float Pow(int a, uint power)
        {
            int y = 1;

            while (true)
            {
                if ((power & 1) != 0)
                {
                    y = a * y;
                }

                power = power >> 1;
                if (power == 0)
                {
                    return y;
                }

                a *= a;
            }
        }
    }
}
