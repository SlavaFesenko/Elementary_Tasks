using System;
using NLog;

namespace Task2Envelopes
{
    public class Envelope : IComparable<Envelope>
    {
        public Logger _log = LogManager.GetCurrentClassLogger();

        #region Props

        public double Height { get; set; }
        public double Width { get; set; }

        #endregion

        #region Ctor

        public Envelope(double height, double width)
        {
            Height = height;
            Width = width;
            _log.Info($"Envelope was created. Width: {width}, Height: {height}");
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
