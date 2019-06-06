using System;

namespace LuckyTickets
{
    public static class TicketHelper
    {
        #region Methods
        public static int[] CreateArrayWithDigits(int number, int quantityDigitsInNumber, int countDigitsInTicket)
        {
            int[] arrayDigits = new int[countDigitsInTicket];

            for (int index = 0; index < countDigitsInTicket - quantityDigitsInNumber; index++)
            {
                arrayDigits[index] = 0;
            }
            string stringNumber = Convert.ToString(number);
            for (int index = countDigitsInTicket - quantityDigitsInNumber, digree = 0; index < countDigitsInTicket; index++, digree++)
            {
                arrayDigits[index] = Convert.ToInt32(stringNumber[digree] - '0');
            }

            return arrayDigits;
        }
        public static int FindNumberDigit(int number)
        {
            int numberDigitInNumber = 0;

            while (number >= 1)
            {
                number /= 10;
                numberDigitInNumber++;
            }

            return numberDigitInNumber;
        }

        #endregion

    }
}
