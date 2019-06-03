using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class UnicodeSkipArray
    {
        private byte _patternLength;
        private byte[] _default;
        private byte[][] _skipTable;
        private const int BLOCK_SIZE = 0x100;

        public UnicodeSkipArray(int patternLength)
        {
            _patternLength = (byte)patternLength;
            _default = new byte[BLOCK_SIZE];
            InitialBlock(_default);
            _skipTable = new byte[BLOCK_SIZE][];

            for (int i = 0; i < BLOCK_SIZE; i++)
                _skipTable[i] = _default;
        }

        public byte this[int index]
        {
            get
            {
                return _skipTable[index / BLOCK_SIZE][index % BLOCK_SIZE];
            }
            set
            {
                int i = index / BLOCK_SIZE;

                if (_skipTable[i] == _default)
                {
                    _skipTable[i] = new byte[BLOCK_SIZE];
                    InitialBlock(_skipTable[i]);
                }

                _skipTable[i][index % BLOCK_SIZE] = value;
            }
        }

        private void InitialBlock(byte[] block)
        {
            for (int i = 0; i < BLOCK_SIZE; i++)
            {
                block[i] = _patternLength;
            }
        }
    }
}
