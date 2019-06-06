using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTask6
{
    public class Ticket
    {

        public int Number { get; set; }
        public int LengthOfNumber { get; set; }
        private Ticket(int number)
        {
            Number = number;
            LengthOfNumber = Number.ToString().ToCharArray().Length;
            if (LengthOfNumber % 2 != 0)
            {
                LengthOfNumber++;
            }
            if (LengthOfNumber < 6)
            {
                LengthOfNumber = 6;
            }
        }
        public static Ticket TicketInitialize(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number of ticket should be positive number");
            }
            else
            {
                return new Ticket(number);
            }
        }
        public override string ToString()
        {
            return Number.ToString();
        }
        public int this[int index]
        {
            get
            {
                if (index >= LengthOfNumber || index < 0)
                {
                    return 0;
                }
                else
                {
                    int position = 10;
                    for (int i = 0; i < index; i++)
                    {
                        position *= 10;
                    }

                    return (int)(Number % position / (position / 10));
                }
            }
        }
    }
}
