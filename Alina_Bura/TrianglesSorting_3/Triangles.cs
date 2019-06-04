using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSorting_3
{
    class Triangle
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
        private Triangle(string n, double a, double b, double c)
        {
            Name = n;
            A = a;
            B = b;
            C = c;
        }

        #endregion

        #region Methods

        public static Triangle Create(string name, double a, double b, double c)
        {
            if (!Validate(a, b, c) || !Validate(b, c, a) || !Validate(a, c, b))
            {
                throw new InvalidTriangleException("Can't create triangle!");
            }

            log.Info($"Triangle {name} ({a},{b},{c}) was created");
            return new Triangle(name, a, b, c);
        }

        private static bool Validate(double a, double b, double c) // IN TRIANGLE OR IN VALIDATOR? 
        {
            if (a + b < c)
            {
                log.Error($"Sum of {a} and {b} is less than {c}");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"[Triangle {Name}]: {Square} cm";
        }

        #endregion
    }
}
