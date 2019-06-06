using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Conerter
{
    class Program
    {
        static void Main(string[] args)
        {
            logger.Debug("Start program");
            InputModel model = GetInputModel(args);
            Controller controller = new Controller();
            controller.Run(model);

            logger.Debug("Successful finish program");
            Console.Read();
        }

        private static InputModel GetInputModel(string[] args)
        {
            int number;
            InputModel inputModel = null;
            if (!Validator.IsLenghtArgsInvalid(args.Length))
            {
                if (Validator.IsNumber(args[0]))
                {
                    number = Convert.ToInt32(args[0]);
                }
                else
                {
                    UI.ShowMessage("Введенное значение не является целым числом");
                    number = UI.ReadParametr();
                }
            }
            else
            {
                UI.ShowInstruction();
                number = UI.ReadParametr();
            }
            try
            {
                inputModel = new InputModel(number);
            }
            catch(ArgumentException ex)
            {
                UI.ShowMessage(ex.Message);
                logger.Error(ex.Message);
                inputModel = null;
            }

            return inputModel;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
