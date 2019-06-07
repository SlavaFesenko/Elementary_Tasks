using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class MoskowTicket: ILuckyAlgorithm
    {
        public bool IsLucky(Ticket moskowTicket)
        {
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < moskowTicket.GetLength(); i++)
            {
                if (i < 3)
                    firstSum  += Convert.ToInt32(moskowTicket[i]);
                else
                    secondSum += Convert.ToInt32(moskowTicket[i]);
            }

            return firstSum == secondSum;
        }
    }
}
