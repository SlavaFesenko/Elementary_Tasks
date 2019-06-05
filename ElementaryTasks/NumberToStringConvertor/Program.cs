using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringConvertor
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            Run(args);          
        }

        public static void Run(string[] args)
        {
            try
            {
                int userNumber = Validator.Validate(args);
                UserInterface.Display(userNumber);
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
