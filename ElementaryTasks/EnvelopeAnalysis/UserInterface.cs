using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalysis
{
    public static class UserInterface
    {
        #region Methods

        public static double Input(string inputSideMessage)
        {            
            bool isSuccess = false;
            double result = 0;

            do
            {
                Console.WriteLine(inputSideMessage);
                isSuccess = double.TryParse(Console.ReadLine(), out result) && Validator.Validate(result); 

                if (!isSuccess)
                    Console.WriteLine(Message.ERROR_MESSAGE);

            } while (!isSuccess);

            Console.WriteLine(Message.SUCCESS_MESSAGE);

            return result;
        }


        public static void Display(string resultOfCompare)
        {
            Console.WriteLine($"Your result of compare:\n{resultOfCompare}");
        }

        public static void ShowErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        #endregion
    }
}
