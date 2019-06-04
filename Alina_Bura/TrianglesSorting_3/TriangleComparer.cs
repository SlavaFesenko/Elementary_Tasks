using NLog;
using System;
using System.Collections.Generic;

namespace TrianglesSorting_3
{
    class TriangleDescBySquareComparer : IComparer<Triangle>
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public int Compare(Triangle t1, Triangle t2)
        {

            if (t1.Square > t2.Square)
            {
                log.Info($"{t1.ToString()} is bigger than {t2.ToString()}");
                return -1;
            }
            if (t1.Square < t2.Square)
            {
                log.Info($"{t1.ToString()} is less than {t2.ToString()}");
                return 1;
            }
            if (t1.Square == t2.Square)
            {
                log.Info($"{t1.ToString()} is equals {t2.ToString()}");
                return 0;
            }
            else
            {
                throw new CantCompareException("Cant compare triangles");
            }
        }
    }
}