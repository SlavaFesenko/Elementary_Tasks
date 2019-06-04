using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                             
namespace SoftServeFirstTasks
{
    class Controller
    {
        private readonly ChessBoard _chessBoard = null;

        public Controller(ChessBoard chessBoard)
        {
            _chessBoard = chessBoard;
        }

        public char GetSymbolForCell(int i, int j)
        {
            switch (_chessBoard.CellSymbolAt(i, j))
            {
                case CellSymbol.Black:
                    return '@';
                case CellSymbol.White:
                    return ' ';
                default:
                    throw new CaseNotFoundException("There are no suitable case!");
            }
        }

        public ConsoleColor GetBackColorForCell(int i, int j)
        {
            switch (_chessBoard.CellBackColorAt(i, j))
            {
                case CellColor.Black:
                    return ConsoleColor.Black;
                case CellColor.White:
                    return ConsoleColor.White;
                case CellColor.Yellow:
                    return ConsoleColor.Yellow;
                case CellColor.Green:
                    return ConsoleColor.Green;
                case CellColor.Red:
                    return ConsoleColor.Red;
                case CellColor.Blue:
                    return ConsoleColor.Blue;
                default: 
                    throw new CaseNotFoundException("There are no suitable case!");
            }
        }

        public ConsoleColor GetForeColorForCell(int i, int j)
        {
            switch (_chessBoard.CellForeColorAt(i, j))
            {
                case CellColor.Black:
                    return ConsoleColor.Black;
                case CellColor.White:
                    return ConsoleColor.White;
                case CellColor.Yellow:
                    return ConsoleColor.Yellow;
                case CellColor.Green:
                    return ConsoleColor.Green;
                case CellColor.Red:
                    return ConsoleColor.Red;
                case CellColor.Blue:
                    return ConsoleColor.Blue;
                default:
                    throw new CaseNotFoundException("There are no suitable case!");
            }
        }        

        public void PrintBoard()
        {
            UI.PrintBoard(_chessBoard.Rows, _chessBoard.Columns);            
        }

    }
}
