using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets_6
{
    static class CounterFactory
    {
        public static Counter GetCounter(TicketsMode mode)
        {
            switch (mode)
            {
                case TicketsMode.Moskov:
                    return new MoskovCounter();
                case TicketsMode.Piter:
                    return new PiterCounter();
                default:
                    throw new CaseNotFoundException();
            }
        }
    }
}
