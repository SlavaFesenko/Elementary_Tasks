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
        Logger _logger = LogManager.GetCurrentClassLogger();

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
                if (Validator.IsValid(args))
                {
                    InputModel input = new InputModel(args);
                    Sequence sequence = new FibonacciSequence(input.LeftNumber, input.RightNumber);
                    IEnumerable<int> sequenceCollection = sequence.GetSequenceCollection();

                    string result = sequence.GetStringSequence(sequenceCollection).ToString();
                    _view.ShowResult(result);
                    _logger.Info($"Application run and show result with valid arguments: " +
                        $"{input.LeftNumber}, {input.RightNumber}");
                    _logger.Info($"Show result: {result}");
                }
            }
            catch (ArgumentException ex)
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

