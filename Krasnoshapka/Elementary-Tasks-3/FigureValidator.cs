
namespace ElementaryTasks3
{
    class FigureValidator
    {
        /// <summary>
        /// Сheck on the possibility of creating a triangle
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="thirdSide"></param>
        /// <returns></returns>
        public static bool ValidSides(float firstSide, float secondSide, float thirdSide)
        {
            return firstSide > 0 
                && secondSide > 0 
                && thirdSide > 0
                && (firstSide + secondSide > thirdSide)
                && (firstSide + thirdSide > secondSide)
                && (secondSide + thirdSide > firstSide);
        }
    }
}
