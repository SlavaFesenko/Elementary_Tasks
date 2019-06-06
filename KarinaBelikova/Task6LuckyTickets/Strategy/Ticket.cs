using System;

namespace Task6LuckyTickets
{
    public class Ticket
    {
        private int[] _digits;

        public int Number { get; set; }
        public int Length { get => _digits.Length; }
        public LuckyAlgorithm Algorithm { get; set; }

        public int this[int index]
        {
            get
            {
                return _digits[index];
            }
        }

        public Ticket(int number, LuckyAlgorithm algorithm)
        {
            Number = number;
            _digits = GetArray(number);
            Algorithm = algorithm;
        }

        private int[] GetArray(int number)
        {
            int[] array = new int[Constants.DIGITS_IN_NUMBER_COUNT];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number % 10;
                number /= 10;
            }

            Array.Reverse(array);
            return array;
        }

        public bool IsLucky()
        {
            return Algorithm.isLuckyTicket(this);
        }
    }
}
