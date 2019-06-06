namespace SoftServeFirstTasks
{
    class WhiteCell : ICell
    {
        public CellSymbol Symbol => CellSymbol.White;

        public CellColor BackColor => CellColor.White;

        public CellColor ForeColor => CellColor.Blue;

    }
}