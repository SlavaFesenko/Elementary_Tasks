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
        Logger logger = LogManager.GetCurrentClassLogger();

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
            logger.Trace("Application start without arguments");
            _view.ShowInstruction(ConfigurationManager.AppSettings["Instruction"]);

            if (ConfigurationManager.AppSettings["ReInputMode"].ToLower() == "true")
            {
                logger.Trace("ReInput mode started");
                Run(_view.ReInput());
            }
        }
        public virtual void Run(string[] args)
        {
            _args = (string[])args.Clone();

            try
            {
                if (Validator.IsValid(_args) && Validator.IsFileExists(_args))
                {
                    InputModel input = new InputModel(_args);
                    
                    if (input.WorkMode == WorkMode.Find)
                    {
                        _parser = new Parser(input.Path);
                        string result = $"File {input.Path}: Count entries \"{input.SearchingString}\"" +
                            $" = {_parser.GetCountEntries(input.SearchingString)}";
                        _view.ShowResult(result);
                        logger.Info($"Application run with valid arguments: {input.Path}, {input.SearchingString}");
                        logger.Info($"Show result:\n {result}");

                    }

                    if (input.WorkMode == WorkMode.Replace)
                    {
                        _parser = new Parser(input.Path);
                        _parser.ReplaceAll(input.SearchingString, input.ReplacementString);
                        string result = $"File {input.Path}: String \"{input.SearchingString}\" " +
                            $"have been replaced to \"{input.ReplacementString}\" " +
                            $"Count = {_parser.GetCountEntries(input.ReplacementString)} times";
                        _view.ShowResult(result);

                        logger.Info($"Application run with valid arguments: {input.Path}," +
                            $" {input.SearchingString}, {input.ReplacementString}");
                        logger.Info($"Show result:\n {result}");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                _view.ShowErrorMessage(ex.Message);
                logger.Error(ex.Message);
                Run();

            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
                logger.Error(ex.Message);
                Run();
            }
        }
        #endregion
    }
}
