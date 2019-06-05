using System;

namespace Task2Envelopes
{
    public class UI
    {
        public static double[] InputEnvelopesData()
        {
            double[] parameters = new double[4];
            Display("Input 4 numbers (width and height for two envelopes): ");         
            
            for (int i = 0; i < parameters.Length; i++)
            {
                if(!double.TryParse(Console.ReadLine(), out parameters[i]) ||
                    !Validator.IsCorrectEnvelopeSide(parameters[i]))
                {
                    IncorrectInput();                   
                    i--;
                }
            }

            return parameters;
        }

        public static void Display(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void IncorrectInput()
        {
            Display("Envelope side must be a number, above zero. Try again: ");           
        }

        public static void ShowErrorMessage(Exception e)
        {
            Display(e.Message);
            Console.ReadLine();
        }

    }
}
