using System;
using Task1_ChessBoard;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //get args


            UI currentUA = new UI();

            currentUA.GetSizeOfParameters();

            string message = currentUA.CalculateOK();
            Console.WriteLine(message);

            currentUA.PrintIntoConsole();
            Console.ReadKey();
        }
    }

}
