using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalysis
{
    public static class UserInterface
    {
        #region Method

        public static (double, double, double, double) Input()
        {
            string[] inputMessages = { "Input width of the first envelope:",
                                       "Input height of the first envelope:",
                                       "Input width of the second envelope:",
                                       "Input height of the second envelope:"};
            string successMessage = "All sides was validated!";
            string errorMessage = "Side wasn't validated! Please, try again!";
            bool isSuccess = false;
            const int COUNT_OF_SIDES = 4;
            double[] result = new double[COUNT_OF_SIDES];

            for (int i = 0; i < COUNT_OF_SIDES; i++)
            {
                do
                {
                    Console.WriteLine(inputMessages[i]);
                    isSuccess = double.TryParse(Console.ReadLine(), out result[i]);
                    Validator.Validate(result[i]);
                    if (!isSuccess)
                        Console.WriteLine(errorMessage);
                } while (!isSuccess);
            }
            Console.WriteLine(successMessage);

            return (result[0], result[1], result[2], result[3]);
        }


        public static void Display(string resultOfCompare)
        {
            Console.WriteLine("Your result of compare:");
            Console.WriteLine(resultOfCompare);
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        #endregion
    }
}
