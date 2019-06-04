using System;
using System.Configuration;

using SharedDll;

namespace Task4FileParser
{
    public class Application
    {
        private string[] _args;
        private IView _view;
        private Parser _parser;

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
                if (Validator.IsValid(_args, out WorkMode mode))
                {
                    if (mode == WorkMode.Find)
                    {
                        _parser = new Parser(_args[0]);
                        _view.ShowResult($"File {_args[0]}: Count entries \"{_args[1]}\" = {_parser.GetCountEntries(_args[1])}");
                    }

                    if (mode == WorkMode.Replace)
                    {
                        _parser = new Parser(_args[0]);
                        _parser.ReplaceAll(_args[1], _args[2]);
                        _view.ShowResult($"File {_args[0]}: String \"{_args[1]}\" have been replaced to \"{_args[2]}\" Count = {_parser.GetCountEntries(_args[2])} times");
                    }
                }
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
