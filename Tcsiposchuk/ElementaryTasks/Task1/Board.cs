using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Board : IBoard
    {
        #region Properties and Fields

        private readonly Cell[,] Cells;

        public int Weight => Cells.GetLength(1);

        public int Height => Cells.GetLength(0);

        #endregion

        #region Indexator

        public Cell this [int indexX, int indexY ]
        {
            get => Cells[indexX, indexY];
            private set => Cells[indexX, indexY] = value;
        }

        #endregion

        #region Constructors
        public Board(int weight, int height)
        {
            Cells = new Cell[weight, height];
            for(int indexX = 0; indexX < weight; indexX++)
            {
                for (int indexY = 0; indexY < height; indexY++)
                {
                    if( (indexX % 2 == 0 && indexY % 2 == 1) || (indexX % 2 == 1 && indexY % 2 == 0) )
                    {
                        this[indexX, indexY] = new Cell(Color.Black);
                    }
                    else
                    {
                        this[indexX, indexY] = new Cell(Color.White);
                    }
                }
            }
        }

        #endregion

    }
}
