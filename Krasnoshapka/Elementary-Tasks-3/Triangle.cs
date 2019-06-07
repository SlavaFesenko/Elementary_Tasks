using System;


namespace ElementaryTasks3
{
    public class Triangle : IFigureBehaviour
    {

        #region Properties

        public string TriangleName { get; set; }
        public float FirstSide { get; set; }
        public float SecondSide { get; set; }
        public float ThirdSide { get; set; }

        #endregion

        #region Methods

        private Triangle(string triangleName, float firstSide, float secondSide, float thirdSide)
        {
            TriangleName = triangleName;
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        /// <summary>
        /// Initializes a new instance of the Triangle.
        /// </summary>
        /// <param name="triangleName">Name of triangle</param>                 
        /// <param name="firstSide">First side of triangle</param>                   
        /// <param name="secondSide">Second side of triangle</param>                  
        /// <param name="thirdSide">Third side of triangle</param>
        /// <returns></returns>
        public static Triangle TriangleInitialize(string triangleName, float firstSide, float secondSide, float thirdSide)
        {
            if (FigureValidator.ValidSides(firstSide, secondSide, thirdSide))
            {
                return new Triangle(triangleName, firstSide, secondSide, thirdSide);
            }
            else
                throw new ArgumentException("Incorrect parameters");
        }

        /// <summary>
        /// Perimeter Calculation
        /// </summary>
        /// <returns>Perimeter</returns>
        public float GetPerimeter()
        {
          return FirstSide + SecondSide + ThirdSide;
        }

        /// <summary>
        /// Area calculation
        /// </summary>
        /// <returns>Area</returns>
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

        #endregion
    }
}
