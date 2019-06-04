using System;

namespace T1_ChessBoard
{
    internal abstract class Cell
    {
        #region Fields

        protected ConsoleColor consoleColor;
        protected int numberInRow;
        protected int numberInColumn;
        protected char symbol;

        #endregion

        #region Properties

        public ConsoleColor ConsoleColor { get => consoleColor; set => consoleColor = value; }
        public int NumberInRow { get => numberInRow; }
        public int NumberInColumn { get => numberInColumn; }
        public char Symbol { get; set; }

        #endregion

    }
}
