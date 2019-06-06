using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    public class Envelope
    {
        #region Fields

        private double _width;
        private double _heigth;

        #endregion
        #region Props

        public double Height
        {
            get
            {
                return _heigth;
            }

            set
            {
                if (value > 0)
                    _heigth = value;
                else throw new ArgumentException("Values must be > 0");
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (value > 0)
                    _width = value;
                else throw new ArgumentException("Values must be > 0");
            }
        }
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
