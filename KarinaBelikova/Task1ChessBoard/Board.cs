
namespace ChessBoardApp
{
    class Board
    {
        public Cell[,] _cells;

        #region Properties
        public int Rows { get; set; }
        public int Columns { get; set; }

        #endregion

        public Cell this[int i, int j]
        {
            get
            {
                return _cells[i, j];
            }
            set
            {
                _cells[i, j] = value;
            }
        }
       
        #region Constructor

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            _cells = new Cell[Rows, Columns];
            BoardInit();
        }

        private void BoardInit()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(i + j % 2 == 0)
                    {
                        _cells[i, j].Color = Color.Black;
                    }
                    else
                    {
                        _cells[i, j].Color = Color.White;
                    }
                }
            }
        }

        #endregion
    }
}
