using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSequence_7
{
    public class SquareSequence : ISequence
    {
        #region Field

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Props
        public int StartNumber { get; }
        public int FinishNumber { get; }

        #endregion

        #region Ctor
        public SquareSequence(int fNumber, int sNumber = 0)
        {
            if (fNumber < 1 || sNumber >= fNumber)
            {
                throw new ArgumentException();
            }

            FinishNumber = fNumber;
            StartNumber = sNumber;
        }

        #endregion

        #region Methods

        public IEnumerable<int> GetSequence()
        {
            for (int i = StartNumber; i * i < FinishNumber; i++)
            {
                log.Info($"Add {i} to sequense");
                yield return i;
            }
        }

        public string GetStringResult(IEnumerable<int> sequence)
        {
            return string.Join(", ", sequence);
        }

        #endregion
    }
}
