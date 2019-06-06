using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApp
{
    class Triangle : IComparable
    {
        #region Properties

        public string Name { get; set; }
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }

        public double Perimeter
        {
            get
            {
                return (FirstSide + SecondSide + ThirdSide);
            }
        }

        public double Square
        {
            get
            {
                double halfPerimeter = Perimeter / 2.0;
                return halfPerimeter * (halfPerimeter - FirstSide) *
                    (halfPerimeter - SecondSide) * (halfPerimeter - ThirdSide);
            }
        }

        #endregion

        #region Constructors

        public Triangle() { }

        public Triangle(string name, double firstSide, double secondSide, double thirdSide)
        {
            Name = name;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        #endregion

        public int CompareTo(object o)
        {
            Triangle triangle = o as Triangle;
            if (triangle != null)
                return this.Square.CompareTo(triangle.Square);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override string ToString()
        {          
            return $"[Triangle {Name}]: {Square:N2} cm";
        }
       
    }
}
