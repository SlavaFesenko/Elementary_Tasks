using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class PiterTicket: ILuckyAlgorithm
    {
        public bool IsLucky(Ticket piterTicket)
        {
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < piterTicket.GetLength(); i++)
            {
                if ((i + 1) % 2 == 0)
                    evenSum += Convert.ToInt32(piterTicket[i]);
                else
                    oddSum += Convert.ToInt32(piterTicket[i]);
            }

            return evenSum == oddSum;
        }
    }
}
