using System;
using System.Collections.Generic;
using System.Text;

namespace T1_ChessBoard
{
    class BoardCell : Cell
    {
        #region Constructors

        public BoardCell(int numberInRow, int numberInColumn, ConsoleColor color)
        {
            this.numberInRow = numberInRow;
            this.numberInColumn = numberInColumn;
            this.consoleColor = color;
        }

        #endregion
    }
}
