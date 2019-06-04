using System;
using System.Collections.Generic;
using System.Text;

namespace T1_ChessBoard
{
    public class Board : IFiguresForGame
    {
        #region Fields

        private int height;
        private int width;
        private BoardCell[,] ChessBoard;

        #endregion

        #region Constructors

        public Board(int height, int widht)
        {
            try
            {
                this.height = height;
                this.width = widht;
                ChessBoard = new BoardCell[height, widht];
                this.FillBoardCollection(ConsoleColor.Blue, ConsoleColor.DarkGray);
            }
            catch (Exception exception)
            {
                //add to log file
            }

        }

        #endregion

        #region Properties

        public int Height { get => height; }
        public int Widht { get => width; }

        #endregion

        #region Indexer

        internal BoardCell this[int index1, int index2] {
            get { return ChessBoard[index1, index2]; }
            private set { ChessBoard[index1, index2] = value; }
        }

        #endregion


        #region Methods
        public void SetFigures(char symbol)
        {
            int[] row = { 0, 1, height - 2, height - 1 };

            foreach (int index1 in row)
            {
                for (int index2 = 0; index2 < width; index2++)
                {
                    ChessBoard[index1, index2].Symbol = symbol;
                }
            }
        }

        public void PrintToConsole()
        {
            for (int index1 = 0; index1 < height; index1++)
            {
                for (int index2 = 0; index2 < width; index2++)
                {
                    Console.BackgroundColor = ChessBoard[index1, index2].ConsoleColor;
                    Console.Write(ChessBoard[index1, index2].Symbol);
                }
                Console.Write("\n");
            }

        }

        private void FillBoardCollection(ConsoleColor color1, ConsoleColor color2)
        {

            for (int index1 = 0; index1 < height; index1++)
            {
                for (int index2 = 0; index2 < width; index2++)
                {
                    if ((index1 + index2) % 2 == 0)

                    {
                        ChessBoard[index1, index2] = CreateNewBoardCellWithParameters(index1, index2, color1);
                    }
                    else
                    {
                        ChessBoard[index1, index2] = CreateNewBoardCellWithParameters(index1, index2, color2);
                    }
                }
            }
        }

        private BoardCell CreateNewBoardCellWithParameters(int index1, int index2, ConsoleColor color)
        {
            BoardCell cell = null;

            cell = new BoardCell(index1, index2, color);

            return cell;
        }

        #endregion
    }
}
