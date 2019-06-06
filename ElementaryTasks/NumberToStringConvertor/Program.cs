using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

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
            Logger log = LogManager.GetCurrentClassLogger();

            try
            {
                log.Info($"User input {args[0]}.");
                int userNumber = Validator.Validate(args);
                UserInterface.Display(userNumber);
            }
            catch (FormatException e)
            {
                log.Error($"Format Exception: e.Message");
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentNullException e)
            {
                log.Error($"Argument Null Exception: {e.Message}");
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentException e)
            {
                log.Error($"Argument Exception: {e.Message}");
                UserInterface.ShowErrorMessage(e);
            }
        }
    }
}
