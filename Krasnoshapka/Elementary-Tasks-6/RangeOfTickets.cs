using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTask6
{
    public abstract class HappyTickets
    {
        public List<Ticket> HappyTicketsInRange;
        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }
        public int CountOfHappyTicket { get; set; }

        protected HappyTickets(int leftBorder, int rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            CountOfHappyTicket = 0;
            HappyTicketsInRange = new List<Ticket>();
        }

        public static bool HappyTicketsInitialize(int leftBorder, int rightBorder)
        {
            if (leftBorder < 0 || rightBorder < 0)
            {
                throw new ArgumentException("Incorect input of borders");
            }
            if (leftBorder > rightBorder)
            {
                throw new ArgumentException("Left border should be less or equal RightBorder");
            }
            else
            {
                return true;
            }

        }

        public abstract bool SequenceOfTicket(Ticket t);
        public IEnumerable<Ticket> GetTickets()
        {
            for (int i = LeftBorder; i <= RightBorder; i++)
            {
                if (SequenceOfTicket(Ticket.TicketInitialize(LeftBorder)))
                {
                    yield return Ticket.TicketInitialize(LeftBorder);
                    LeftBorder++;
                    CountOfHappyTicket++;
                }
                else LeftBorder++;
            }

        }

    }
}
