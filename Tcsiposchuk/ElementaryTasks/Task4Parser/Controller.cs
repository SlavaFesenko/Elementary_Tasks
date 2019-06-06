using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Parser
{
    public class Controller : BaseController
    {

        public void Run(string[] args)
        {
            InputModel input = GetInputModel(args);
            Parser parser = new Parser(input);
            try
            {
                UI.ShowReturn(parser.WorkMode, parser.Execute());
            }
            catch(Exception ex)
            {
                UI.ShowMessage(ex.Message);
            }
            
        }

        private static InputModel GetInputModel(string[] args)
        {
            InputModel input = null;
            switch (args.Length)
            {
                case 2:
                    if (Validator.IsPathValid(args[0]))
                    {
                        input = new InputModel(args[1], args[0]);
                    }
                    break;
                case 3:
                    if (Validator.IsPathValid(args[0]))
                    {
                        input = new InputModel(args[2], args[1], args[0]);
                    }                    
                    break;
                default:
                    break;
            }
            if (input == null)
            {
                GetInputModel(UI.GetParamsFromConsole());
            }
            return input;
        }
    }
}
