using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelopes
{
    public class Envelope : IComparable<Envelope>
    {
        #region Props

        public double Height { get; set; }
        public double Width { get; set; }

        #endregion

        #region Ctor

        public Envelope(double height, double width)
        {
            Height = height;
            Width = width;
        }

        #endregion

        #region Methode

        public int CompareTo(Envelope other)
        {
            if ((this.Height > other.Height) && (this.Width > other.Width))
            {
                return 1;
            }
            else if ((this.Height == other.Height) && (this.Width == other.Width))
            {
                return 0;
            }
            else
                return -1;
        }

        #endregion

    }
}
