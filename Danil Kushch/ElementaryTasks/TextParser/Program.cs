using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hi, my name is Danya.";
            string pattern = "name";

            BoyerMoore algorithm = new BoyerMoore(pattern);          

            Console.WriteLine(algorithm.Search(text));
            Console.ReadLine();
        }
    }
}
