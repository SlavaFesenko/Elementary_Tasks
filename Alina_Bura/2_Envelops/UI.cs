using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelops_2
{
    class UI
    {
        public static double[] ReadParameters()
        {
            double[] parameters = new double[4];
            Console.WriteLine("Input 1st side of 1st envelop: ");
            parameters[0] = double.Parse(Console.ReadLine());
            Console.WriteLine("Input 2st side of 1st envelop: ");
            parameters[1] = double.Parse(Console.ReadLine());
            Console.WriteLine("Input 1st side of 2st envelop: ");
            parameters[2] = double.Parse(Console.ReadLine());
            Console.WriteLine("Input 2st side of 2st envelop: ");
            parameters[3] = double.Parse(Console.ReadLine());
            return parameters;
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowInstruction()
        {
            Console.WriteLine("Input numbers more than 0");
        }
       
        public static bool ProposeAgain()
        {
            bool repeat = false;
            Console.WriteLine("Would you analyze again?");
            string s = Console.ReadLine();
            if (s == "y" || s == "yes")
            {
                repeat = true;
            }
            return repeat;
        }
    }
}
