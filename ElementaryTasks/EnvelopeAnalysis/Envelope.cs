using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalysis
{
    public class Envelope
    {
        #region Prvt Fields

        private double _width;
        private double _height;

        #endregion

        #region Props

        public double Width  
        { 
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public double Height 
        { 
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        #endregion

        #region Ctor

        public Envelope(double width, double height)
        {
            _width = width;
            _height = height;
        }

        #endregion

        #region Methods

        public bool DoesAbleToPutIn(Envelope envelopeToCompare)
        {
            return (_width >= envelopeToCompare.Width) && (_height >= envelopeToCompare.Height);
        }

        #endregion

    }
}
