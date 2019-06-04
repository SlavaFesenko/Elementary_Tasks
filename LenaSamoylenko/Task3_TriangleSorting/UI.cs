using System;
using System.Text;
using CommonThings;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Task3_TriangleSorting
{
    class UI : BaseUI
    {
        #region Fields

        private string row;
        private string _instruction = null;
        private int _taskNumber = 0;
        private TriangleList _triangles = new TriangleList();

        private Logger _logger = null;
        private IServiceProvider _provider = null;
        private IExeptionForFirstDemo _exeptions = null;

        #endregion


        #region Constructors

        public UI()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _taskNumber = (int)TaskNumber.Task8;
            _instruction = InstructionReader.GiveInstruction();
            _exeptions = new ExceptionsForAllAplication(_taskNumber);

            Console.WriteLine("{0} Hello in Task{1} {0}", new string('*', 10), _taskNumber);
        }

        #endregion

        #region Properties

        public char DecisionToContinueProgramm { get => Logic.DecisionToContinue(); }
        public string Row { get => row; set => row = value; }

        #endregion

        #region Methods

        public void Print()
        {
            _triangles.Print();
        }

        public override string CalculateOK()
        {
            string message = null;
            using (_provider as IDisposable)
            {
                _provider = CommonThings.Logger<Wrapper>.HelperForLogging();
                var _wrapper = _provider.GetRequiredService<Wrapper>();
                message=_wrapper.GetCycle(_exeptions);
            }
            
            return message;
        }

        public override string PrintIntoConsole()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
