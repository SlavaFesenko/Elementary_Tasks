using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    class Application
    {
        private string[] _args;
        private IView _view;
        //private Envelope _envelope;

        public Application()
        {
            _view = new ConsoleView();
        }

        public Application(IView view)
        {
            _view = view;
        }
        public virtual void Run()
        {
            _view.ShowInstruction(ConfigurationManager.AppSettings["Instruction"]);
            Run(_view.ReInput());
        }
        public virtual void Run(string[] args)
        {
            _args = (string[])args.Clone();
            try
            {
                
            }
            catch (ArgumentException ex)
            {
                _view.ShowErrorMessage(ex.Message);
                Run();
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
                Run();
            }
        }
    }
}
