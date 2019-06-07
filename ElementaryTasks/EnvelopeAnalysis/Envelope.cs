using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalysis
{
    public class Envelope
    {
        #region Props

        public double Width  { get; set; }
        public double Height { get; set; }

        #endregion

        #region Ctor

        public Envelope(double width, double height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Methods

        public bool DoesAbleToPutIn(Envelope envelopeToCompare)
        {
            return (Width >= envelopeToCompare.Width) && (Height >= envelopeToCompare.Height);
        }

        #endregion

    }
}
