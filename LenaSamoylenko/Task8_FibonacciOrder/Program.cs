using System;

namespace Task8_FibonacciOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string _message1 = null;
            string _message2 = null;
            string _data = null;

            //greating
          

            //creating new UI 
            UI currentUI = new UI(args);
            
            currentUI.CheckForExit(_message1);

            //get calculation`s result and print message
            _message2 = currentUI.CalculateOK();
            Console.WriteLine(_message2);

            //get results and print it
            _data = currentUI.PrintIntoConsole();
            Console.WriteLine(_data);

            Console.ReadKey();
        }
    }
}
