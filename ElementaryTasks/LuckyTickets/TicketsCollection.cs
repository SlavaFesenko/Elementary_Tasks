using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LuckyTickets
{
    public class TicketsCollection
    {
        #region Prvt Field

        private List<Ticket> _ticketsList = new List<Ticket>();

        #endregion

        #region Methods

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

        #endregion
    }
}
