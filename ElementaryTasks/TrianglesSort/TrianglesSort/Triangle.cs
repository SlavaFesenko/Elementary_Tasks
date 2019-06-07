using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort
{
    public class Triangle:ICloneable
    {
        #region Props
        
        public string Name       { get; set; }
        public double FirstSide  { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide  { get; set; }

        public double Square
        {
            get
            {
                double halfPer = Perimetr / 2.0;// half of the perimetr
                // differences
                double diff1 = halfPer - FirstSide;
                double diff2 = halfPer - SecondSide;
                double diff3 = halfPer - ThirdSide;

                return Math.Sqrt(halfPer * diff1 * diff2 * diff3);
            }
        }

        public double Perimetr
        {
            get
            {
                double perimetr = FirstSide + SecondSide + ThirdSide;

                return perimetr;
            }
        }

        #endregion

        #region Ctor

        public Triangle(string name, double firstSide, double secondSide, double thirdSide)
        {
            Name = name;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;        
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"[{Name}]: {Square:N2}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion   
    }
}
