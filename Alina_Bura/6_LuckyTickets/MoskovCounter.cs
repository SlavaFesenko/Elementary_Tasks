using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    class MoskovCounter : Counter
    {
        public override int GetCount(int digitsCount, int startIndex, int finishIndex)
        {
            int count = 0;
            int middle = digitsCount / 2;

            for (int i = startIndex; i < finishIndex; i++)
            {
                Ticket t = new Ticket(i, digitsCount);
                if (GetSum(t.Digits, 0, middle) == GetSum(t.Digits, middle, digitsCount))
                {
                    count++;
                }
            }

            return count;
        }       
    }
}
