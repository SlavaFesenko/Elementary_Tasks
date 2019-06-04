using System;

namespace Task8_FibonacciOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string _message = null;
            string _data = null;

            //creating new UI 
            UI currentUI = new UI(args);

            //get calculation`s result and print message
            _message = currentUI.CalculateOK();
            currentUI.PrintMessage(_message);

            //get results and print it
            _data = currentUI.PrintIntoConsole();
            currentUI.PrintMessage(_data);

            currentUI.Exit();

            Console.ReadKey();
        }
    }
}
