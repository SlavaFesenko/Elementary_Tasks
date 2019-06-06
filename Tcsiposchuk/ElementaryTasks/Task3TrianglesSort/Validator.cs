using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TrianglesSort
{
    public class Validator
    {
        internal static bool IsNumber(string input)
        {
            return Double.TryParse(input, out double temp);
        }
    }
}
