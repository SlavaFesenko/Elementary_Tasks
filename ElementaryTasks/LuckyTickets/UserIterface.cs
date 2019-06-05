using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public static class UserIterface
    {
        public static void Display(TicketsCollection tickets)
        {
            Console.WriteLine($"Count of lucky tickets: {tickets.CountOfLuckyTickets()}");
        }
    }
}
