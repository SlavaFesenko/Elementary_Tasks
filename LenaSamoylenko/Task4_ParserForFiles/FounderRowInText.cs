using System;

namespace Task4_ParserForFiles
{
    public abstract class FounderRowInText
    {
        #region Const

        const int THREADSIZE = 100;

        #endregion

        #region Fields

        private string _row;
        private readonly string _textPath;
        private string _text;
        private int _textSize;
        private int _rowSize;
        private int _countOfThread;
        #endregion

        #region Constructors

        public FounderRowInText(string textPath)
        {
            _textPath = textPath;
        }

        #endregion

        #region Properties

        public string Row { get => _row; protected set => _row = value; }
        public string TextPath { get => _textPath; }
        public int CountOfThread { get => _countOfThread; protected set => _countOfThread = value; }
        public int RowSize { get => _rowSize; protected set => _rowSize = value; }
        public int TextSize { get => _textSize; protected set => _textSize = value; }
        public string Text { get => _text; protected set => _text = value; }


        #endregion

    }

}
