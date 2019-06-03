using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_6
{
    public class MoscowMethod : HappyTickets
    {
        private MoscowMethod(int LeftBorder, int RightBorder) : base(LeftBorder, RightBorder)
        { }
        public static MoscowMethod MoscovMethodInitialize(int leftBorder, int rightBorder)
        {
            if (HappyTicketsInitialize(leftBorder, rightBorder))
            {
                return new MoscowMethod(leftBorder, rightBorder);
            }
            else
            {
                throw new ArgumentException("Wrong borders!");
            }
        }

        public override bool SequenceOfTicket(Ticket ticket)
        {
            int firstPart = 0;
            int secondPart = 0;

            for (int i = 0; i < ticket.LengthOfNumber / 2; i++)
            {
                firstPart += ticket[i];
                secondPart += ticket[i + (ticket.LengthOfNumber / 2)];
            }

            if (firstPart == secondPart)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
