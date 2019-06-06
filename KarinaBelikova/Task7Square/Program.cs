using System;

namespace Task7Square
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputModel model = new InputModel(args);
                Application.Run(model);
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
