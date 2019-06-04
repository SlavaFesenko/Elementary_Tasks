using System;

namespace Task7_NumbersOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string _message = null;
            string _data = null;

            //greating
            Console.WriteLine("Hello in Task7");

            //creating new UI 
            UI currentUI = new UI(args);

            //get calculation`s result and print message
            _message = currentUI.CalculateOK();
            Console.WriteLine(_message);

            //get results and print it
            _data = currentUI.PrintIntoConsole();
            Console.WriteLine(_data);

            Console.ReadKey();
        }
    }
}
