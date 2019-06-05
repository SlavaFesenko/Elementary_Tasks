using System;

namespace Task2Envelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Application.Run();
                }
                while (!Application.Exit());               
            }
            catch (FormatException e)
            {
                UI.ShowErrorMessage(e);
            }           
        }
    }
}
