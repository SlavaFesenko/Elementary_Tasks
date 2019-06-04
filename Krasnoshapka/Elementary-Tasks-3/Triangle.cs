using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_3
{
    class Triangle : IFigure
    {
        public string TriangleName { get; set; }
        public float FirstSide { get; set; }
        public float SecondSide { get; set; }
        public float ThirdSide { get; set; }

        private Triangle(string triangleName, float firstSide, float secondSide, float thirdSide)
        {
            TriangleName = triangleName;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public static Triangle TriangleInitialize(string triangleName, float firstSide, float secondSide, float thirdSide)
        {
            if (Validator.ValidSides(firstSide, secondSide, thirdSide))
            {
                return new Triangle(triangleName, firstSide, secondSide, thirdSide);
            }
            else
                throw new ArgumentException("Incorrect parameters");
        }

        public float GetPerimeter()
        {
          return FirstSide + SecondSide + ThirdSide;
        }

        public float GetSquare()
        {
            float HalfPerimeter = GetPerimeter() / 2;
            return (float)Math.Sqrt(HalfPerimeter * (HalfPerimeter - FirstSide) 
                * (HalfPerimeter - SecondSide) * (HalfPerimeter - ThirdSide));
        }

        public override string ToString()
        {
            return string.Format($"[Triangle {this.TriangleName}]: {this.GetSquare()} cm");
        }
    }
}
