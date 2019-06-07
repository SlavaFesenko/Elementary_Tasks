using NLog;

namespace ElementaryTask7
{
    class Validator
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Сheck on the possibility of creating a sequence
        /// </summary>
        /// <param name="rightBorder">Number which the sequence seeks</param>
        /// <returns>Success</returns>
        public static bool ValidSquare(int rightBorder)
        {
            bool result = false;
            if (rightBorder > 1)
            {
                result = true;
                logger.Trace("Successful validate");
            }
            return result;
        } 

    }
}
