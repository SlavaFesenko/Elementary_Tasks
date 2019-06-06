using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class Ticket
    {
        #region Indexator, Fields, Properties
        public int[] DigitsTicket { get => _numberTicket; }

        public int this[int index]
        {
            get
            {
                return DigitsTicket[index];
            }
        }

        private readonly int[] _numberTicket;


        #endregion

        #region Constructor

        public Ticket(int number, int countDigitsInTicket)
        {
            _numberTicket = TicketHelper.CreateArrayWithDigits(number, TicketHelper.FindNumberDigit(number), countDigitsInTicket);

        }

        #endregion


    }
}
