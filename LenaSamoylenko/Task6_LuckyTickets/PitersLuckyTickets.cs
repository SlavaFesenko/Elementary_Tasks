﻿using System;
using System.Collections.Generic;

namespace Task6_LuckyTickets
{
    //done!
    class PitersLuckyTickets : LuckyTickets 
    {
        #region Fields

        private Ticket ticket;
        private IEnumerable<long> tickets = null;
        #endregion

        #region Constructors

        public PitersLuckyTickets(long border1, long border2)
        {
            ticket = new Ticket(border1, border2);
           
        }

        #endregion

        #region Properties

        public long LowerBorder => ticket.LowerBorder;

        public long UpperBorder => ticket.UpperBorder;

        #endregion

        public int this[long index]
        {
            get => CommonThings.GetCountsOfDigits(index);
        }

        #region Methods

        public int CountLuckyTickets()
        {
            int count = 0;
            IEnumerable<long> collection = GetCollectionOfTickets();

            foreach (var ticket in collection)
            {
                count++;
            }

            return count;
        }

        public IEnumerable<long> GetCollectionOfTickets()
        {

            for (long ticket = this.ticket.LowerBorder; ticket <= this.ticket.UpperBorder; ticket++)
            {
                List<int> oddNumber = GetOddNumberNumbers(ticket, out List<int> evenNumber);

                if (IsLeningradConditionalTrue(oddNumber, evenNumber) == true)
                {
                    yield return ticket;
                }
            }

        }


        private bool IsLeningradConditionalTrue(IEnumerable<int> oddNumbers, IEnumerable<int> evenNumbers)
        {
            bool result = false;
            int sumOdd = 0;
            int sumEven = 0;

            foreach (var odd in oddNumbers)
            {
                sumOdd += odd;
            }

            foreach (var even in evenNumbers)
            {
                sumEven += even;
            }

            if (sumOdd.Equals(sumEven))
            {
                result = true;
            }

            return result;
        }
        #endregion

        /// <summary>
        /// To get Arralist of odd&even numbers
        /// </summary>
        /// <param name="number">Checking number</param>
        /// <param name="rank">Rank of number</param>
        /// <param name="evenNumberNumbers">ArrayList to out even numbers</param>
        /// <returns>ArrayList to out odd numbers</returns>
        public List<int> GetOddNumberNumbers(long number, out List<int> evenNumberNumbers)
        {
            List<int> oddNumberNumbers = new List<int>();    //нечетные
            evenNumberNumbers = new List<int>();             //четные

            List<int> forFind = new List<int>();

            int rank = this[number];
            int rankDifferencesSix = 6 - rank;

            if (rankDifferencesSix > 0)
            {
                for (int i = 0; i < rankDifferencesSix; i++)
                {
                    forFind.Add(0);
                }
            }
            else if (rank % 2 == 1)
            {
                rank++;
                number = number * 10;
            }

            for (int digit = rank; digit >= 1; digit--)
            {

                long tenInPow = (long)Math.Pow(10, (digit - 1));
                var currentRankDigit = (int)(number / tenInPow);

                forFind.Add(currentRankDigit);

                number = number - tenInPow * currentRankDigit;
            }


            for (int index = 0; index < forFind.Count; index++)
            {
                if (index % 2 == 0)
                {
                    oddNumberNumbers.Add(forFind[index]);
                }
                else
                {
                    evenNumberNumbers.Add(forFind[index]);
                }
            }

            return oddNumberNumbers;
        }

    }
}
