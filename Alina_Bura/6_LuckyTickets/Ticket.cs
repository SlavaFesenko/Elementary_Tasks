using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    class Ticket
    {
        private readonly int _number;

        public int this[int index] => Digits[index];

        public List<int> Digits
        {
            get
            {
                return _number.ToString().ToCharArray().Select(n => n - '0').ToList();
            }                
        }

        public Ticket(int n, int digitsCount)
        {
            _number = n;
            AddZeros(digitsCount);
        }

        private void AddZeros(int digitsCount)
        {
            if (Digits.Count < digitsCount)
            {
                int zerosCount = digitsCount - Digits.Count;
                for (int j = 0; j < zerosCount; j++)
                {
                    Digits.Insert(j, 0);
                }
            }
        }
    }
}
