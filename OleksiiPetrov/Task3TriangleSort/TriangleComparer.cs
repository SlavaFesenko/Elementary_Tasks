using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TriangleSort
{
    public class TrianglesComparer:IComparer<Triangle>
    {
        public int Compare(Triangle first, Triangle second)
        {
            if (first.Area > second.Area)
            {
                return -1;
            }
            else if (first.Area < second.Area)
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
