namespace Task1
{
    public interface IBoard
    {
        Cell this[int indexX, int indexY]
        {
            get;
        }

        int Weight { get; }

        int Height { get; }
    }
}