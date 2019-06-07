﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// Abstract class for common sequence
    /// </summary>
    public abstract class Sequence
    {
        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }

        public Sequence(int leftBorder, int rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }

        public abstract IEnumerable<int> GetSequence();
    }
}
