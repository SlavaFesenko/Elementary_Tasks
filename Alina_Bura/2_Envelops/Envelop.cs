using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelops_2
{
    class Envelop : IComparable<Envelop>
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Envelop(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public bool CanPutInside(Envelop e)
        {
            if (CompareTo(e) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Envelop e1)
        {
            if (Math.Max(Width, Height) > Math.Max(e1.Width, e1.Height)
                && Math.Min(Width, Height) > Math.Min(e1.Width, e1.Height))
            {
                return 1;
            }
            if (Math.Max(Width, Height) <= Math.Max(e1.Width, e1.Height)
                && Math.Min(Width, Height) <= Math.Min(e1.Width, e1.Height))
            {
                return -1;
            }
            else
            {
                throw new CantCompareException("Cant compare envelops");
            }
        }
    }
}
