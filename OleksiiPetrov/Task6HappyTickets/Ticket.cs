using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6HappyTickets
{
    public class Ticket
    {
        private int[] _numbers = null;
        private ILuckyAlgorithm _algorithm;

        public Ticket(int[] numbers, LuckyTicketType luckyTicketType)
        {
            _numbers = numbers;
            if (luckyTicketType == LuckyTicketType.Moskow)
                _algorithm = new MoskowTicket();
            else if (luckyTicketType == LuckyTicketType.Piter)
                _algorithm = new PiterTicket();
        }

        public bool IsLucky()
        {
            return _algorithm.IsLucky(this);
        }

        public int GetLength()
        {
            return _numbers.Length;
        }

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
    }
}
