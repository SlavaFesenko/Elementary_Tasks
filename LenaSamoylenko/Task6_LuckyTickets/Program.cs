using System;
using System.Collections;

namespace Task6_LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            UA currentUA = new UA();
            Console.WriteLine("PUT 1st border");
            //currentUA.AfterValidationHeight(Console.ReadLine());
            Console.WriteLine("Put 2nd border");
            //currentUA.AfterValidationWeigth(Console.ReadLine());

            currentUA.PutOK();
            currentUA.PrintCollection();
            currentUA.PrintCount();

            Console.ReadKey();
        }
    }
}
