 using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSorting_3
{
    public class Triangle
    {
        #region Field

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Props
        public string Name { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Perimeter
        {
            get
            {
                return A + B + C;
            }
        }

        public double Square
        {
            get
            {
                double p = Perimeter / 2.0;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        #endregion

        #region Ctor
        public Triangle(string n, double a, double b, double c)
        {
            if (!Validate(a, b, c) || !Validate(b, c, a) || !Validate(a, c, b))
            {
                throw new ArgumentException("Can't create triangle!");
            }

            Name = n;
            A = a;
            B = b;
            C = c;
        } 

        #endregion

        #region Methods
       
        private static bool Validate(double a, double b, double c)
        {
            if (a + b <= c || a <= 0 || b <= 0 || c <= 0)
            {
                log.Error($"Sum of {a} and {b} is less than {c}");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"[Triangle {Name}]: {Square:0.####} cm";
        }

        #endregion
    }
}
