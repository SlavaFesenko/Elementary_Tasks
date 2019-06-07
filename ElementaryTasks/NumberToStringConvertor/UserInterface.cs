using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NumberToStringConvertor
{
    public static class UserInterface
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static void ShowErrorMessage(Exception e)
        {
            _log.Info(e.Message);
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void Display(int number)
        {
            string convertedNumber = Converter.Convert(number);

            Console.WriteLine($"Your number {number} was converted to string:");
            Console.WriteLine(convertedNumber);

            _log.Info($"{number} was converted to {convertedNumber}");
            Console.ReadLine();
        }       
    }
}
