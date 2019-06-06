using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    abstract class Counter
    {
        public abstract int GetCount(int digits, int startIndex, int finishIndex);
        
        protected int GetSum(List<int> digits, int startIndex, int endIndex)
        {
            int sum = 0;

            for (int i = startIndex; i < endIndex; i++)
            {
                sum += digits[i];
            }
            return sum;
        }
    }
}
