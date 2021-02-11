using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6HappyTickets
{
    public static class Validator
    {
        private const int LENGTH_OF_NUMBERS = 6;

        public static int[] ValidateNumberAndReturnArray(string numbers)
        {
            List<int> ticketNumbers = new List<int>();
            int number = 0;
            if (!(numbers.Length == LENGTH_OF_NUMBERS))
                throw new ArgumentException("Ticket must have only 6 numbers in itself!");

            foreach (char ch in numbers)
            {
                if (int.TryParse(ch.ToString(), out number))
                    ticketNumbers.Add(number);
                else
                    throw new ArgumentException("Invalid type of numbers");
            }

            return ticketNumbers.ToArray();
        }
    }
}
