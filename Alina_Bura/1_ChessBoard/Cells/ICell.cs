using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeFirstTasks
{
    interface ICell
    {
        CellSymbol Symbol { get; }
        CellColor BackColor { get; }
        CellColor ForeColor { get; }
    }
}
