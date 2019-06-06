using NLog;

namespace ElementaryTask7
{
    class Validator
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

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
