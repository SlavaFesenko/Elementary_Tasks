using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence_8
{
    class FibonacciSequence : ISequence
    {
        #region Field

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Props
        public int StartRange { get; }
        public int FinishRange { get; }

        #endregion

        #region Ctor
        public FibonacciSequence(int s, int f)
        {
            StartRange = s;
            FinishRange = f;
        }

        #endregion

        #region Methods

        public IEnumerable<int> GetSequence()
        {
            int i = 0;
            int Step = 1;
            
            while (i + Step <= FinishRange)
            {
                i += Step;
                Step = i - Step;
                yield return i;
            }
        }

        public string GetStringResult(IEnumerable<int> sequence)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int item in sequence)
            {
                if (item >= StartRange && item <= FinishRange)
                {
                    sb.Append($"{item},");
                    log.Info($"Add to sequence {item}");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            log.Info(sb);
            return sb.ToString();
        }

        #endregion
    }
}
