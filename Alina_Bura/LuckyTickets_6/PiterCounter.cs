using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    class PiterCounter : Counter
    {
        public override int GetCount(int digitsCount)
        {
            int count = 0;
            for (int i = 0; i < Math.Pow(10, digitsCount); i++)
            {
                Ticket t = new Ticket(i, digitsCount);

                List<int> oddDigits = t.Digits.Select(x => x).Where(x => x % 2 == 0).ToList();
                List<int> evenDigits = t.Digits.Select(x => x).Where(x => x % 2 != 0).ToList();

                if (GetSum(oddDigits, 0, oddDigits.Count) == GetSum(evenDigits, 0, evenDigits.Count))
                {
                    count++;
                }
            }
            return count;
        }        
    }
}
