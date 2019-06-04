using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence_8
{
    static class UI
    {
        internal static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal static void ShowInstruction()
        {
            Console.WriteLine("Input 1 integer number via console");
            Console.WriteLine("Example: 10");
        }
    }
}
