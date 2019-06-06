using System;

namespace Task8Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {               
                Application.Run(args);
            }
            catch (FormatException e)
            {
                UI.ShowErrorMessage(e);
            }
            catch (ArgumentNullException e)
            {
                UI.ShowErrorMessage(e);
            }
            catch (ArgumentException e)
            {
                UI.ShowErrorMessage(e);
            }
        }
    }
}
