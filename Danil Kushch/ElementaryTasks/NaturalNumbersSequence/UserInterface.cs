using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalNumbersSequence
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
            Console.WriteLine("Your sequence is");
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        #endregion
    }
}
