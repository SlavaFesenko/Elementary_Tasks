using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6HappyTickets
{
    class Ticket : IEnumerable
    {
        private sbyte[] _numbers;
        //public sbyte Number { set; get; }

        public Ticket(params sbyte[] digits)
        {
            _numbers = digits;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _numbers.GetEnumerator();
        }
    }
}
