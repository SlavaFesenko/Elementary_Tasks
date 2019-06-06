using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    class BlackCell : ICell
    {
        public CellSymbol Symbol => CellSymbol.Black;
        public CellColor BackColor => CellColor.Blue;
        public CellColor ForeColor => CellColor.White;
    }
}
