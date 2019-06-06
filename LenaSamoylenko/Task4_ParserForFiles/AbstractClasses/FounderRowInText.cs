using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;
using Microsoft.Extensions.Logging;
using NLog;

namespace Task4_ParserForFiles
{
    public abstract class FounderRowInText : IRowFounder
    {
        #region Const

        const int THREADSIZE = 100;

        #endregion

        #region Fields
        private int _taskNumber = 0;
        protected ILogger<FounderRowInText> _logger = null;
        protected IServiceProvider _servicesProvider = null;
        protected IExeptionForFirstDemo _exeptions = null;

        private Encoding _currentEncoding = null;
        protected List<int> _changedParts = null;
        private string _row;
        //private readonly string _textPath;
        private string _text;
        private int _textSize;
        private int _rowSize;
        private int _countOfThread;
        #endregion

        #region Constructors

        public FounderRowInText(IServiceProvider provider, ILogger<FounderRowInText> logger)
        {
            _logger = logger;
            _servicesProvider = provider;

            _taskNumber = (int)TaskNumber.Task4;

            _exeptions = new ExceptionsForAllAplication(_taskNumber);
        }

        #endregion

        #region Properties

        public string Row { get => _row; protected set => _row = value; }
        //public string TextPath { get => _textPath; }
        public int CountOfThread { get => _countOfThread; protected set => _countOfThread = value; }
        public int RowSize { get => _rowSize; protected set => _rowSize = value; }
        public int TextSize { get => _textSize; protected set => _textSize = value; }
        public string Text { get => _text; protected set => _text = value; }
        internal List<int> ChangedParts { get => _changedParts; }
        internal Encoding CurrentEncoding { get => _currentEncoding;}
        #endregion

        #region Methods
        public void GetText(string textPath)
        {
            bool isTextReadable = false;
            try
            {
                isTextReadable = InstructionReader.IsCouldGetText(textPath, out string _text, out _currentEncoding);
                if (isTextReadable == true)
                {
                    TextSize = _text.Length;
                    Text = _text;
                }
            }
            catch (Exception exception)
            {
                Exception exceptionFinal = _exeptions.GetException(exception);
                _logger.LogError(exceptionFinal, "Stopped program because of exception in method {0}",
                                                    System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public virtual void NewFileWithNewRows(List<int> forChangeParts, string oldRow, string pathNewFile, string newRow = null)
        { }

        public abstract bool CountOfRowInText(string oldRow, out int count);
        public abstract string GetNewFilePath(string textPath);

        #endregion
    }

}
