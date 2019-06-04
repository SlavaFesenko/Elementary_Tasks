using System;

namespace Task2_EnvelopesAnalizer
{
    internal class EnvelopesAnalizer<T> : IAnalyze where T : class, IEnvelopeTemplate
    {
        #region Fields

        private T firstOne;
        private T secondOne;

        #endregion

        #region Constructors

        public EnvelopesAnalizer(T _firstOne, T _secondOne)
        {
            firstOne = _firstOne;
            secondOne = _secondOne;
        }

        #endregion


        #region Methods

        public bool IsTrueUsualAnalyzer()
        {
            bool result;

            if (secondOne.Height > firstOne.Height)
            {
                result = (secondOne.Wigth > firstOne.Wigth) ? true : false;
            }
            else if (firstOne.Height > secondOne.Height)
            {
                result = (firstOne.Wigth > secondOne.Wigth) ? true : false;

            }
            else //if firstOne.Height.Equals(secondOne.Height)&&firstOne.Wigth.Equals(secondOne.Wigth)
            {
                result = false;
            }

            return result;
        }

        public bool IsTrueAnalyzerWithAngle()
        {
            bool result=false;
            try
            {
                if (firstOne.Height > secondOne.Height)
                {
                    result = IsCouldBeIncide(
                        a: secondOne.Height,
                        b: secondOne.Wigth,
                        p: firstOne.Height,
                        q: firstOne.Wigth
                        );
                }
                else if (secondOne.Height > firstOne.Height)
                {
                    result = IsCouldBeIncide(
                        a: firstOne.Height,
                        b: firstOne.Wigth,
                        p: secondOne.Height,
                        q: secondOne.Wigth
                        );
                }
            }
            catch (Exception exception)
            {
                //add to log

               
            }

            return result;
        }

        private bool IsCouldBeIncide(double a, double b, double p, double q)
        {
            bool result;
            double qInPow = Math.Pow(p, 2);
            double pInPow = Math.Pow(q, 2);
            double aInPow = Math.Pow(a, 2);
            double sqrt = Math.Sqrt(qInPow + pInPow + aInPow);

            result = b >= (2 * p * q * a + (qInPow + pInPow) * sqrt) / (qInPow + pInPow) ? true : false;

            return result;
        }

        #endregion

    }
}
