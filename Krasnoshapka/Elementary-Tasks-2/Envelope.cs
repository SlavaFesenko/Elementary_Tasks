using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_2
{
    class Envelope : IComparable<Envelope>
    {
        public float Height { get; private set; }
        public float Width { get; private set; }
        private Envelope(float height, float width)
        {
            Height = height;
            Width = width;
        }

        public static Envelope EnvelopeInitialize(float height, float width)
        {
            if (height > 0 && width > 0)
            {
                return new Envelope(height, width);
            }
            else
            {
                throw new ArgumentException("Incorrect parameters");
            }
        }

        public int CompareTo(Envelope secondEnvelope)
        {
            if ((this.Height > secondEnvelope.Height) && (this.Width > secondEnvelope.Width))
            {
                return 1;
            }
            else if ((this.Height == secondEnvelope.Height) && (this.Width == secondEnvelope.Width))
            {
                return 0;
            }
            else
                return -1;

        }

    }
}