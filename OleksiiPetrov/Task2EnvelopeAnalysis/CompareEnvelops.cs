using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    public class CompareEnvelops
    {
        private Envelope _firstEnvelope;
        private Envelope _secondEnvelope;

        public CompareEnvelops(Envelope firstEnvelope, Envelope secondEnvelope)
        {
            _firstEnvelope = firstEnvelope;
            _secondEnvelope = secondEnvelope;
        }

        public string GetResult()
        {
            bool isFirstCanBeNestedInSecond = _firstEnvelope.CanBeNested(_secondEnvelope);
            bool isSecondCanBeNestedInFirst = _secondEnvelope.CanBeNested(_firstEnvelope);

            string result = string.Empty;

            if (isFirstCanBeNestedInSecond)
                result += "Second envelope can be put in the first envelope.\n";

            if (isSecondCanBeNestedInFirst)
                result += "First envelope can be put in the second envelope.\n";

            if (!isFirstCanBeNestedInSecond && !isSecondCanBeNestedInFirst)
                result += "None of the envelopes can be placed in another.\n";

            return result;
        }
    }
}
