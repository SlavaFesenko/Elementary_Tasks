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

        public static void Validate(double side)
        {
            if (side < 0)
                Console.WriteLine("The side must be bigger than 0!");
        }

        #endregion
    }
}
