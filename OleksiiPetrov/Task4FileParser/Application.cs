using System;
using System.Configuration;
using NLog;
using SharedLibrary;

namespace Task4FileParser
{
    public class Application
    {
        #region Fields

        private string[] _args;
        private IView _view;
        private Parser _parser;
        Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctors

        public Application()
        {
            _view = new ConsoleView();
        }

        public Application(IView view)
        {
            _view = view;
        }

        #endregion

        #region Methods
        public virtual void Run()
        {
            _logger.Trace("Application start without arguments");
            _view.ShowInstruction(ConfigurationManager.AppSettings["Instruction"]);

            if (ConfigurationManager.AppSettings["ReInputMode"].ToLower() == "true")
            {
                _logger.Trace("ReInput mode started");
                Run(_view.ReInput());
            }
        }
        public virtual void Run(string[] args)
        {
            _args = (string[])args.Clone();

            _logger.Info($"Application run with arguments: ");
            foreach (var item in _args)
            {
                _logger.Trace(item + " ");
            }
            try
            {
                if (Validator.IsValid(_args) && Validator.IsFileExists(_args))
                {
                    InputModel input = new InputModel(_args);
                    
                    if (input.WorkMode == WorkMode.Find)
                    {
                        _parser = new Parser(input.Source);
                        int count = _parser.GetCountEntries(input.SearchingString);

                        string result = $"File {input.Source}: Count entries \"{input.SearchingString}\" = {count}";

                        _view.ShowResult(result);
                        _logger.Info($"Application run with valid arguments: {input.Source}, {input.SearchingString}");
                        _logger.Info($"Show result:\n {result}");

                    }

                    if (input.WorkMode == WorkMode.Replace)
                    {
                        _parser = new Parser(input.Source);
                        _parser.ReplaceAll(input.SearchingString, input.ReplacementString);

                        string result = $"File {input.Source}: String \"{input.SearchingString}\" " +
                            $"have been replaced to \"{input.ReplacementString}\" ";

                        _view.ShowResult(result);
                        _logger.Info($"Application run with valid arguments: {input.Source}," +
                            $" {input.SearchingString}, {input.ReplacementString}");
                        _logger.Info($"Show result:\n {result}");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                _view.ShowErrorMessage(ex.Message);
                _logger.Error(ex.Message);
                Run();

            }
            catch (NullReferenceException ex)
            {
                _view.ShowErrorMessage("Attention" + ex.Message);
                _logger.Error(ex.Message);
                Run();

            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage("Attention" + ex.Message);
                _logger.Error(ex.Message);
                Run();
            }
        }

        #endregion
    }
}
