using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalysis
{
    public static class Validator
    {
        #region Method

        public static bool Validate(double side)
        {
            if (side <= 0)
            {
                Console.WriteLine("The side must be greater than 0!");

                return false;
            }
            else
                return 
                    true;
        }

        #endregion
    }
}
