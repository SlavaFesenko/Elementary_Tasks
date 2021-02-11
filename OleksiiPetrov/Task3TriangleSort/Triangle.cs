using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TriangleSort
{
    public class Triangle : ICloneable
    {
        private double _perimeter;
        private double _sideOne;
        private double _sideTwo;
        private double _sideThree;

        public string Name { set; get; }
        public double Area { set; get; }

        public Triangle(string name, double sideOne, double sideTwo, double sideThree)
        {
            Name = name;
            _sideOne = sideOne;
            _sideTwo = sideTwo;
            _sideThree = sideThree;
            _perimeter = GetPerimeter();
            GetCalculatedArea();
        }

        #region Methods

        private double GetPerimeter()
        {
            return _perimeter = _sideOne + _sideTwo + _sideThree;
        }

        private double GetCalculatedArea()
        {
            double halfPerimeter = _perimeter / 2.0;
            Area = Math.Sqrt(halfPerimeter * (halfPerimeter - _sideOne) *
                (halfPerimeter - _sideTwo) * (halfPerimeter - _sideThree));

            return Area;
        }

        public override string ToString()
        {
            return $"[{Name}]: {Area:N2} cm";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}
