using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class Ticket
    {
        #region Prvt field

        private int[] _numbers = null;
        private ILuckyAlgorithm _algorithm;

        #endregion

        #region Indexator

        public int this[int index]
        {
            get
            {
                return _numbers[index];
            }
            set
            {
                _numbers[index] = value;
            }
        }

        #endregion

        #region Ctor

        public Ticket(int[] numbers, LuckyTicketType luckyTicketType)
        {
            _numbers  = numbers;
            if (luckyTicketType == LuckyTicketType.Moskow)
                _algorithm = new MoskowTicket();
            else if (luckyTicketType == LuckyTicketType.Piter)
                _algorithm = new PiterTicket();
        }

        #endregion

        #region Methods

        public bool IsLucky()
        {
            return _algorithm.IsLucky(this);
        }

        public int GetLength()
        {
            return _numbers.Length;
        }

        #endregion
    }
}
