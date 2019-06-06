using System;

namespace Task3TrianglesSort
{
    public class InputModel
    {
        public string Name { get; set; }
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }

        public InputModel(string name, double firstSide, double secondSide, double thirdSide)
        {
            if ((firstSide < 0) || (thirdSide < 0) || (secondSide < 0))
            {
                throw new ArgumentException("Одна или несколько сторон меньше нуля");
            }
            if ((firstSide + secondSide < thirdSide) || (firstSide + thirdSide < secondSide) || (secondSide + thirdSide < firstSide))
            {
                throw new ArgumentException("С указанными сторонами невозможно построить треугольник");
            }

            Name = name;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

        }
    }
}
