using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6HappyTickets
{
    public class TicketsCollection
    {
        private List<Ticket> _ticketsList;

        public TicketsCollection()
        {
            _ticketsList = new List<Ticket>();
        }

        public void Add(params Ticket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                _ticketsList.Add(tickets[i]);
            }
        }

        public int CountOfLuckyTickets()
        {
            int counter = 0;

            foreach (Ticket ticket in _ticketsList)
            {
                if (ticket.IsLucky())
                    counter++;
            }

            return counter;
        }
    }
}
