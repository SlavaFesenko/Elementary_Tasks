using System;
using System.Collections.Generic;

namespace Task3TrianglesSort
{
    public class Triangle : IComparer<Triangle>, IComparable<Triangle>
    {
        #region Properties
        public string Name { get; set; }
        public double FirstSide { get; private set; }
        public double SecondSide { get; private set; }
        public double ThirdSide { get; private set; }

        public double SemiPerimeter
        {
            get => (FirstSide + ThirdSide + SecondSide) / 2;
        }

        public double Square
        {
            get => Math.Sqrt(SemiPerimeter * (SemiPerimeter - FirstSide) * (SemiPerimeter - SecondSide) * (SemiPerimeter - ThirdSide));
        }

        #endregion

        #region Constructors

        public Triangle(InputModel inputModel)
        {
            Name = inputModel.Name;
            FirstSide = inputModel.FirstSide;
            SecondSide = inputModel.SecondSide;
            ThirdSide = inputModel.ThirdSide;
        }

        #endregion

        int IComparer<Triangle>.Compare(Triangle x, Triangle y)
        {
            return x.Square.CompareTo(y.Square);
        }

        public override string ToString()
        {
            return String.Format("[Треугольник {0}] : {1} см", Name, Square);
        }

        public int CompareTo(Triangle other)
        {
            return this.Square.CompareTo(other.Square);
        }
    }
}
