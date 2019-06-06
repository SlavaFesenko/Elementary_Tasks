using System;
namespace Task6LuckyTickets
{
    public class MoskowAlgorithm : LuckyAlgorithm
    {
        public override bool isLuckyTicket(Ticket ticket)
        {
            int firstPartSum = 0;
            int secondPartSum = 0;

            for (int i = 0; i < ticket.Length; i++)
            {
                if (i < 3)
                    firstPartSum += Convert.ToInt32(ticket[i]);
                else
                    secondPartSum += Convert.ToInt32(ticket[i]);
            }

            return firstPartSum == secondPartSum;
        }
    }
}
