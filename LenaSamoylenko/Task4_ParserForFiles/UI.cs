using System;
using System.IO;
using CommonThings;
using NLog;

namespace Task4_ParserForFiles
{
    internal class UI : BaseUI
    {
        #region Fields

        private FounderRowInText _founder = null;
        private string _instruction = null;
        private string[] _args = Array.Empty<string>();

        private Logger _logger = null;
        private IDisposable _servicesProvider = null;

        #endregion

        #region Constructors

        private UI()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _servicesProvider = CommonThings.Logger<UI>.HelperForLogging() as IDisposable;
        }

        public UI(string[] args, out string message) : this()
        {
            int _lenght = args.Length;
            message = null; //messsage from validator
            _instruction = InstructionReader.GiveInstruction();

            Console.WriteLine(_instruction);

            try
            {
                if (_lenght == 2)
                {
                    if (Validator.IsFileExist(args[0], out message) == true)
                    {
                        _founder = new CounterRowInText(args[0]);
                    }
                    else
                    {
                        Console.WriteLine(message);
                        Exit();
                    }
                }
                else if (_lenght == 3)
                {
                    if (Validator.IsFileExist(args[0], out message) == true)
                    {
                        _founder = new CnangerRowInText(args[0]);
                    }
                    else
                    {
                        Console.WriteLine(message);
                        Exit();
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, there are some error with count of agrs");
                    Exit();
                }

                _args = args;//not so sure

            }
            catch (Exception exception)
            {
                //add
            }

        }

        #endregion

        #region Methods

        public override string CalculateOK()
        {
            string _message = null;
            int _count = 0;
            if (_founder is ChangePart)
            {
                CnangerRowInText changer = new CnangerRowInText(_args[0]);
                string newFilePath = changer.GetNewFilePath(changer.TextPath);
                changer.CountOfRow(_args[1], _args[2], out _count);
                changer.NewFileWithNewRows(changer.ChangedParts, changer.NewRow, changer.Row, newFilePath);

            }
            //_count = _founder.GetRowCountInText(_args[1]);
            if (_count != 0)
            {
                _message = $"Congratulations, there are {_count} times you could see row in the text";
            }
            else
            {
                _message = "There are no coincidences in text";
            }

            return _message;
        }

        public override string PrintIntoConsole()
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            Console.WriteLine("The programm will be close");
            //add to log file
            Environment.Exit(0);
        }


        #endregion
    }

}
