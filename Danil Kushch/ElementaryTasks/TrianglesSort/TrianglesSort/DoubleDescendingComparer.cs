using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort
{
    public class DoubleDescendingComparer: IComparer<double>
    { 
        public int Compare(double value1, double value2)
        {
            if (value1 > value2)
            {
                return -1;
            }
            else if (value1 < value2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
