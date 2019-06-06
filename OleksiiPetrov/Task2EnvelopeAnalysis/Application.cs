using NLog;
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
        const int COUNT_OF_SIDES = 4;
        #region Fields

        private string[] _args;
        private Task2EnvelopeAnalysis.IView _view;
        private Envelope _envelope;
        Logger logger = LogManager.GetCurrentClassLogger();
        private string[] sidesEnvelopsString;
        private double[] sidesEnvelops;

        #endregion

        #region Ctors

        public Application()
        {
            _view = new ConsoleView();
            sidesEnvelops = new double[COUNT_OF_SIDES];
            sidesEnvelopsString = new string[COUNT_OF_SIDES];
        }

        public Application(IView view)
        {
            _view = view;
        }

        #endregion

        #region Methods
        public virtual void Run()
        {
            bool isRetry = false;

            try
            {
                do
                {
                    InputEnvelops(out Envelope firstEnvelope, out Envelope secondEnvelope);
                    CompareEnvelops compare = new CompareEnvelops(firstEnvelope, secondEnvelope);

                    _view.ShowResult(compare.GetResult());
                    string answer = _view.Input("Will you still compare envelopes? \n" +
                        "(Input 'Y' or 'YES' for continue, or any another key to exit)\n").ToLower();

                    if (answer == "y" || answer == "yes")
                    {
                        isRetry = true;
                    }
                    else isRetry = false;

                } while (isRetry);

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

        private void InputEnvelops(out Envelope firstEnvelope, out Envelope secondEnvelope)
        {
            string[] inputMessages = { "Input width of the first envelope: ",
                                       "Input height of the first envelope: ",
                                       "Input width of the second envelope: ",
                                       "Input height of the second envelope: "};
            bool isSuccess = false;


            for (int i = 0; i < COUNT_OF_SIDES; i++)
            {
                do
                {
                    sidesEnvelopsString[i] = _view.Input(inputMessages[i]);
                    isSuccess = double.TryParse(sidesEnvelopsString[i], out sidesEnvelops[i]);
                    if (!isSuccess)
                        _view.ShowErrorMessage("Values is not double! Please try again.");
                } while (!isSuccess);
            }

            firstEnvelope = new Envelope(sidesEnvelops[0], sidesEnvelops[1]);
            secondEnvelope = new Envelope(sidesEnvelops[2], sidesEnvelops[3]);
        }
        #endregion
    }
}
