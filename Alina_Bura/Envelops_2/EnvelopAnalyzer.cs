using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelops_2
{
    static class EnvelopAnalyzer
    {
        public static string Analyze(Envelop e1, Envelop e2)
        {
            if (e1.CanPutInside(e2))
            {
                return $"Envelop ({e2.Height}, {e2.Width}) can put inside envelop ({e1.Height}, {e1.Width})";
            }
            if (e2.CanPutInside(e1))
            {
                return $"Envelop ({e1.Height}, {e1.Width}) can put inside envelop ({e2.Height}, {e2.Width})";
            }
            else
            {
                return "You can't put envelops inside";
            }
        }
    }
}
