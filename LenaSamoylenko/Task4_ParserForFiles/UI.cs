using CommonThings;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;

namespace Task4_ParserForFiles
{
    internal class UI : BaseUI
    {
        #region Fields

        private string _instruction = null;
        private string[] _args = Array.Empty<string>();
        private int _taskNumber = 0;

        private FounderRowInText _founder = null;
        private Logger _logger = null;
        private IServiceProvider _servicesProvider = null;
        protected IExeptionForFirstDemo _exeptions = null;
        private List<string> _messages = new List<string>
        {
            "Put full file path",
            "Put row which you want to find",
            "Put new row, if you want to replace previous"};

        #endregion

        #region Constructors

        private UI()
        {
            string _instrLink = InstructionReader.GetFilePath();

            _logger = LogManager.GetCurrentClassLogger();
            _taskNumber = (int)TaskNumber.Task4;
            _instruction = InstructionReader.GiveInstruction(_instrLink, _logger);

            Console.WriteLine("{0} Hello in Task{1} {0}", new string('*', 10), _taskNumber);
        }

        public UI(string[] args) : this()
        {
            bool _isContinue = true;
            bool _isTextFileExist = false;
            _args = new string[(int)CountOfArgs.FourthTaskSecond];

            Console.WriteLine(_instruction);

            while (_isContinue)
            {
                int _lenght = args.Length;
                if (_lenght != 0)
                {
                    _args[0] = args[0];
                    _args[1] = args[1];
                    _isTextFileExist = Validator.IsFileExist(args[0]);
                }

                using (_servicesProvider as IDisposable)
                {
                    if (_lenght != 0 && _isTextFileExist == true)
                    {
                        if (_lenght == (int)CountOfArgs.FourthTaskFirst
                            || (_lenght == (int)CountOfArgs.FourthTaskSecond && args[2] == ""))
                        {
                            _servicesProvider = Logger<CounterRowInText>.HelperForLogging();

                            _founder = _servicesProvider.GetRequiredService<CounterRowInText>();
                            _founder.GetText(args[0]);
                            _isContinue = false;
                        }
                        else if (_lenght == (int)CountOfArgs.FourthTaskSecond)
                        {
                            _args[2] = args[2];

                            _servicesProvider = Logger<CnangerRowInText>.HelperForLogging();

                            _founder = _servicesProvider.GetRequiredService<CnangerRowInText>();
                            _founder.GetText(args[0]);
                            _isContinue = false;
                        }
                    }
                    else
                    {
                        string message = "Sorry, there are some error with count or type of agrs.\nPlease put agrument again";
                        Console.WriteLine(message);

                        for (int i = 0; i < (int)CountOfArgs.FourthTaskSecond; i++)
                        {
                            _args[i] = Parser.GetArgument(_messages[i]);
                        }
                        args = _args;
                    }
                }
            }

            string mesForUser = String.Format("You choose TextPath:\t{0}\nRow for find:\t{1}\nNew row in text:\t{2}",
                _args[0], _args[1], _args[2]);
            PrintToUser(mesForUser);
        }

        #endregion

        #region Methods

        public override string CalculateOK()
        {
            string _message = null;
            int _count = 0;

            string newFilePath = _founder.GetNewFilePath(_args[0]);
            _founder.CountOfRowInText(_args[1], out _count);

            _founder.NewFileWithNewRows(_founder.ChangedParts, _args[1], newFilePath, newRow: _args[2]);

            if (_count != 0)
            {
                _message = $"Congratulations, there are {_count} times you could see row in the text from file {_args[0]}";
            }
            else
            {
                _message = "There are no coincidences in text";
            }

            PrintToUser(_message);

            return _message;
        }

        public override string PrintIntoConsole()
        {
            throw new NotImplementedException();
        }


        private void PrintToUser(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
        #endregion
    }

}
