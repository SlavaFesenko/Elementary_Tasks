using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTasks
{
    public class Cell
    {
        #region Props
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsDark { get; set; }
        #endregion

        #region Ctor
        public Cell(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
        #endregion


    }
}
