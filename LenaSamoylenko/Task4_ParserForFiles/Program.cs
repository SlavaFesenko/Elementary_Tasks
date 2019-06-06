using System;

namespace Task4_ParserForFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating new UI 
            UI currentUI = new UI(args);

            //get calculation`s result and print message
            currentUI.CalculateOK();
            
            //get results and print it
            //_data = currentUI.PrintIntoConsole();
            //Console.WriteLine(_data);

            Console.ReadKey();
        }
    }

}
