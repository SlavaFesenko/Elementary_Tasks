using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
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
                UI.Display(Validator.Validate(args));
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
