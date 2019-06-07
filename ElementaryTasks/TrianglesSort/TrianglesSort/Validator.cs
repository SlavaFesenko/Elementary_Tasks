using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort
{
    public static class Validator
    {
        #region Methods

        public static Triangle ValidatingArgsToTriangle(string[] args)
        {
            if (args.Length == 0)
                throw new FormatException("Please input arguments!");

            if (args.Length != 4)
                throw new FormatException("Unsuccessful inputing format!");
            else
            {
                double side1 = ValidateWithTryParse(args[1]);
                double side2 = ValidateWithTryParse(args[2]);
                double side3 = ValidateWithTryParse(args[3]);

                if (side1 > 0 && side2 >0 && side3 >0)
                {
                    if (IsExistsTriangle(side1,side2,side3))
                    {
                        Triangle _validatedTriangle = new Triangle(args[0], side1, side2, side3);

                        return _validatedTriangle;
                    }
                    else
                        throw new ArgumentException("Triangle couldn't be built!");
                }
                else
                    throw new ArgumentException("Sides must be greater than 0!");
            }
        }

        private static bool IsExistsTriangle(double firstSide, double secondSide, double thirdSide)
        {
            bool Result = true;
            if (firstSide + secondSide < thirdSide && Result) Result = false;
            if (secondSide + thirdSide < firstSide && Result) Result = false;
            if (firstSide + thirdSide < secondSide && Result) Result = false;

            return Result;
        }

        private static double ValidateWithTryParse(string arg)
        {
            double side = 0;
            if (double.TryParse(arg, out side))
                return side;
            else
                throw new ArgumentException("Usuccessful type for argument");
        }
     
        #endregion
    }
}
