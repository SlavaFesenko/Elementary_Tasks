using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    class ChessBoard
    {
        #region Fields

        private ICell[,] _cells;

        #endregion

        #region Props
        public int Rows { get; set; }
        public int Columns { get; set; }

        #endregion

        #region Ctor
        public ChessBoard(int r, int c)
        {
            Rows = r;
            Columns = c;
            InitBoard();
        }
        #endregion

        #region Methods
        private void InitBoard()
        {
            _cells = new ICell[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        _cells[i, j] = new WhiteCell();
                    }
                    else
                    {
                        _cells[i, j] = new BlackCell();
                    }
                }
            }
        }

        public CellSymbol CellSymbolAt(int i, int j)
        {
            return _cells[i, j].Symbol;
        }

        public CellColor CellBackColorAt(int i, int j)
        {
            return _cells[i, j].BackColor;
        }

        public CellColor CellForeColorAt(int i, int j)
        {
            return _cells[i, j].ForeColor;
        }

        #endregion

    }
}
