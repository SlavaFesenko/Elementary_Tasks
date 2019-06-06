using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class TicketAnalyzator
    {
        #region Constructors

        public TicketAnalyzator(int startNumberRange, int finishNumberRange, ITicketAlgorithm algorithm)
        {
            StartNumberRange = startNumberRange;
            FinishNumberRange = finishNumberRange;
            _ticketAlgorithm = algorithm;
            
        }

        #endregion

        #region Properties

        public ITicketAlgorithm GetAlgorithmLuckyTickets { get => _ticketAlgorithm; }
        public int StartNumberRange
        {
            get
            {
                return _startNumberRange;
            }
            set
            {
                if(value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value can`t be less than one");
                }
                else
                {
                    _startNumberRange = value;
                }
            }
        }
        public int FinishNumberRange
        {
            get
            {
                return _finishNumberRange;
            }
            set
            {
                if (value < 1 || value < StartNumberRange)
                {
                    throw new ArgumentOutOfRangeException( value < 0 ? "Value can`t be less than one" : "Finish number can`t be less than start");
                }
                else
                {
                    _finishNumberRange = value;
                }
            }
        }

        #endregion

        #region Fields

        private int _startNumberRange;
        private int _finishNumberRange;
        private int _countLuckyTickets = 0;
        private int _countDigitsInTicket = 6;
        private readonly ITicketAlgorithm _ticketAlgorithm;

        #endregion

        #region Methods

        public int CountLuckyTickets()
        {
            _countLuckyTickets = 0;

            for (int indexer = StartNumberRange; indexer <= FinishNumberRange; indexer++)
            {
                if (GetAlgorithmLuckyTickets.IsTicketLucky(new Ticket(indexer, _countDigitsInTicket)))
                {
                    _countLuckyTickets++;
                    //foreach (var st in new Ticket(indexer, _countDigitsInTicket).DigitsTicket)
                    //{
                    //    Console.Write(st);

                    //}
                    //Console.WriteLine();
                }
            }

            return _countLuckyTickets;
        }


        #endregion

    }
}
