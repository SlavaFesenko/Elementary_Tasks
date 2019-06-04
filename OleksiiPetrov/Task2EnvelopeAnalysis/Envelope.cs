using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    class Envelope
    {
        #region Props
        public double Width { get; set; }
        public double Height { get; set; }
        #endregion

        public Envelope(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public bool CanBeNested(Envelope envelopeToCompare)
        {
            return (Width >= envelopeToCompare.Width) && (Height >= envelopeToCompare.Height);
        }
    }
}
