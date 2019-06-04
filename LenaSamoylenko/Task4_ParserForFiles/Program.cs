using System;

namespace Task4_ParserForFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string _message1 = null;
            string _message2 = null;
            string _data = null;

            //greating
            Console.WriteLine("Hello in Task4\n");

            //creating new UI 
            UI currentUI = new UI(args, out _message1);
            //Console.WriteLine(_message1);
            
            //get calculation`s result and print message
            _message2 = currentUI.CalculateOK();
            Console.WriteLine(_message2);

            //get results and print it
            //_data = currentUI.PrintIntoConsole();
            //Console.WriteLine(_data);

            Console.ReadKey();
        }
    }

}
