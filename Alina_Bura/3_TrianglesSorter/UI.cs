using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrianglesSorting_3
{
    static class UI
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public static void ShowInstruction()
        {
            Console.WriteLine("Input name and 3 sides of triangle");
            Console.WriteLine("Template: <name>, <side>, <side>, <side>");
        }

        public static string[] ReadParameters()
        {
            Console.WriteLine("Input triangle params");
            string[] parameters =  Console.ReadLine().Split(',');
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim('\t', ' ');
            }
            return parameters;
        }

        public static bool ProposeAgain()
        {
            bool repeat = false;
            Console.WriteLine("Would you add another triangle?");
            string s = Console.ReadLine().ToLower();
            if (s == "y" || s == "yes")
            {
                repeat = true;
            }
            return repeat;
        }

        public static void PrintTriangleList<Triangle>(List<Triangle> triangles)
        {
            Console.WriteLine("=======Triangle List=======");
            for (int i = 0; i < triangles.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {triangles[i].ToString()}");
            }
        }

        public static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}