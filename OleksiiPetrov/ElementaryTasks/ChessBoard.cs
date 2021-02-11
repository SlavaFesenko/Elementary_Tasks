using System;

namespace ElementaryTasks
{
    public class ChessBoard : ISurface
    {
        #region Fields & CONST
        private const int DEFAULT_HEIGHT = 8;
        private const int DEFAULT_WIDTH = 8;
        private int _height;
        private int _width;
        #endregion

        #region Props
        public Cell[,] Cells { get; private set; }
        public int Height
        {
            get { return _height; }
            set
            {
                _height = Validate(value);
            }
        }
        public int Width
        {
            get { return _width; }
            set
            {
                _width = Validate(value);
            }
        }
        #endregion

        #region Ctors
        public ChessBoard() : this(DEFAULT_HEIGHT, DEFAULT_WIDTH)
        {
        }
        public ChessBoard(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            Cells = GetEmptySurface();
        }
        #endregion

        public Cell[,] GetEmptySurface()
        {
            Cells = new Cell[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells[i,j] = new Cell(i, j);

                    Cells[i,j].IsDark = true;
                    if (i % 2 == 1)
                        if (j % 2 == 1)
                            Cells[i,j].IsDark = false;
                        else
                            Cells[i,j].IsDark = true;
                    else
                    if (j % 2 == 1)
                        Cells[i, j].IsDark = true;
                    else
                        Cells[i, j].IsDark = false;
                }

            }
            
            return Cells;
        }

        private int Validate(int side)
        {
            if ((side > 0) && (side <= 2147483647))
            {
                return side;
            }
            else throw new ArgumentException("The value length of sides must be set in a segment: 0 < value < 2147483647");
        }
    }
}