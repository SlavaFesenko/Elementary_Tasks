﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_3
{
    class TrianglesCompare: IComparer<IFigureBehaviour>
    {
        public int Compare(IFigureBehaviour x, IFigureBehaviour y)
        {
            if (x.GetSquare() < y.GetSquare())
            {
                return 1;
            }
            else if (x.GetSquare() > y.GetSquare())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
