using System;
using System.Collections.Generic;
using System.Text;
using CommonThings.Interfaces;


namespace Task6_LuckyTickets
{
    class Ticket : IBorderLongTemplate
    {
        private long lowerBorder;
        private long upperBorder;

        public Ticket(long border1, long border2)
        {
            if (border1 > border2)
            {
                lowerBorder = border2;
                upperBorder = border1;
            }
            else if (border2 > border1)
            {
                lowerBorder = border1;
                upperBorder = border2;
            }
            else
            {
                lowerBorder = upperBorder = border1;
            }
        }

        public long LowerBorder => lowerBorder;

        public long UpperBorder => upperBorder;
    }
}
