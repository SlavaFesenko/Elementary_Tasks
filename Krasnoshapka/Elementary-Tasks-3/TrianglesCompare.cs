using System.Collections.Generic;

namespace ElementaryTasks3
{
    /// <summary>
    /// Method for comparing triangle
    /// </summary>
    public class TrianglesCompare: IComparer<IFigureBehaviour>
    {
        public int Compare(IFigureBehaviour x, IFigureBehaviour y)
        {
            if (x.GetSquare() < y.GetSquare())
            {
                return 1;
            }
            else if (x.GetSquare() > y.GetSquare())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
