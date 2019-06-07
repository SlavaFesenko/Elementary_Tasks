using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRange
{
    public static class UserInterface
    {
        #region Methods

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        public static void Display(string answer)
        {
            Console.WriteLine("Your range is");
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        #endregion
    }
}
