using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Conerter
{
    public class Validator
    {
        #region Methods

        public static bool IsNumber(string number)
        {
            return Int32.TryParse(number, out int result);
        }

        public static bool IsLenghtArgsInvalid(int length)
        {
            return length != 1;
        }

        #endregion
    }
}
