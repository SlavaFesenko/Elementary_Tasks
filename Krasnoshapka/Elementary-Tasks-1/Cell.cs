using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTask1
{
    public enum Colors
    {
        White,
        Black

    }

    public class Cell
    {
        public Colors Color { get; set; }

        public Cell(Colors color)
        {
            Color = color;
        }

    }
}
