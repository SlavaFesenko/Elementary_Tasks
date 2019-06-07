using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRange
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
                (int beginOfRange, int endOfRange) = Validator.Validate(args);
                Range userRange = new Range(beginOfRange, endOfRange);

                UserInterface.Display(userRange.ShowRange());
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
