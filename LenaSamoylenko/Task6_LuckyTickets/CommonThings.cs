using System;

namespace Task6_LuckyTickets
{
    static class CommonThings
    {
        public static int GetCountsOfDigits(long number)
        {
            int result;

            result = (int)((number == 0) ? 1 : Math.Ceiling(Math.Log10(Math.Abs(number) + 0.5)));

            return result;
        }

    }
}
