using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryTask1
{
    class Board
    {
            public int Height { get; private set; }
            public int Width { get; private set; }

            private Board(int height, int width)
            {
                Height = height;
                Width = width;
                SetCells();
            }

            public Cell[,] Cells { get; set; }


            private void SetCells()
            {
                this.Cells = new Cell[Height, Width];

                for (int height = 0; height < Height; height++)
                {
                    for (int width = 0; width < Width; width++)
                    {
                        if ((height % 2) == (width % 2))
                        {
                            Cells[height, width] = new Cell(Colors.White);
                        }
                        else
                        {
                            Cells[height, width] = new Cell(Colors.Black);
                        }
                    }
                }
            }

            public static Board Create(int height, int width)
            {
                if ((height > 0 && width > 0) && (height % 2 == 0 && width % 2 == 0))
                {
                    return new Board(height, width);
                }
                else
                {
                    throw new ArgumentException("Incorrect width or height.");
                }

            }
    }
    
}
