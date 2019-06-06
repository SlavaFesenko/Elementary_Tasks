using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_6
{
    public class PiterMethod : HappyTickets
    {
        private PiterMethod(int LeftBorder, int RightBorder) : base(LeftBorder, RightBorder)
        { }

        public static PiterMethod PiterMethodInitialize(int leftBorder, int rightBorder)
        {
            if (HappyTicketsInitialize(leftBorder, rightBorder))
            {
                return new PiterMethod(leftBorder, rightBorder);
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
            for (int i = 0; i <= ticket.LengthOfNumber; i++)
            {
                firstPart += ticket[i];
                secondPart += ticket[++i];
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
