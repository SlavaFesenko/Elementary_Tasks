using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelops_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect;
            bool repeat;
            double[] parameters;

            do
            {
                do
                {
                    parameters = UI.ReadParameters();
                    isCorrect = Validator.Validate(parameters, out string message);
                    
                    if (!isCorrect)
                    {
                        if (!string.IsNullOrEmpty(message))
                        {
                            UI.PrintMessage(message);
                        }
                        UI.ShowInstruction();
                    }
                } while (!isCorrect);

                try
                {
                    Envelop e1 = new Envelop(parameters[0], parameters[1]);
                    Envelop e2 = new Envelop(parameters[2], parameters[3]);

                    string result = EnvelopAnalyzer.Analyze(e1, e2);
                    UI.PrintMessage(result);
;               }
                catch (CantCompareException ex)
                {
                    UI.PrintMessage(ex.Message);
                }
                    
                repeat = UI.ProposeAgain();
                
            } while (repeat);

            Console.ReadLine();
        }
    }
}
