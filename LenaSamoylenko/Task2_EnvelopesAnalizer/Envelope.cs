using System.Collections.Generic;
using System.Text;

namespace Task2_EnvelopesAnalizer
{
    internal class Envelope : IEnvelopeTemplate
    {

        #region Fields
        private double height;
        private double wigth;

        #endregion

        #region Constructors

        public Envelope(double size1, double size2)
        {
            if (size1 >= size2)
            {
                height = size2;
                wigth = size1;
            }
            else
            {
                height = size1;
                wigth = size2;
            }
        }

        #endregion

        #region Properties

        public double Height => height;
        public double Wigth => wigth;

        #endregion

    }
}
