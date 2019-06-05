using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalNumbersSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(args);
        }

        public static void Run(string[] args)
        {
            try
            {
                int userNumber = Validator.Validate(args);
                Sequence userSequence = new Sequence(userNumber);
                UserInterface.Display(userSequence.ShowSequence());
            }
            catch (FormatException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentNullException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
        }
    }
}
