using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        #region Prop

        public Cell[,] CellsTable { get; set; }
        public int Rows     { get; set; }
        public int Columns  { get; set; }

        #endregion

        #region Ctor

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns  = columns;

            CellsTable = new Cell[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    CellsTable[i, j] = new Cell(i + 1, j + 1);
                }
            }

        }

        #endregion
    }
}
