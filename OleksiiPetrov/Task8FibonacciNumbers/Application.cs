using System;
using System.Configuration;
using System.Collections.Generic;

using SharedLibrary;
using NLog;

namespace Task8FibonacciNumbers
{
    public class Application
    {
        #region Fields

        private string[] _args;
        private IView _view;
        Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctors

        public Application()
        {
            _view = new SequenceUI();
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
                if (Validator.IsValid(args))
                {
                    InputModel input = new InputModel(args);
                    Sequence sequence = new FibonacciSequence(input.LeftNumber, input.RightNumber);
                    IEnumerable<int> sequenceCollection = sequence.GetSequenceCollection();

                    string result = sequence.GetStringSequence(sequenceCollection).ToString();
                    _view.ShowResult(result);
                    logger.Info($"Application run and show result with valid arguments: {input.LeftNumber}, {input.RightNumber}");
                    logger.Info($"Show result: {result}");
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

