using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class UI : BaseUI
    {
        internal static void ShowInstruction()
        {
            ShowMessage("Это первое задание. Мы строим доску с заданными значениями.");
            ShowMessage("Введите 2 целых числа, которые больше 0 и меньше 33.");
        }

        internal static int ReadParametr()
        {
            int result;

            do
            {
                ShowMessage("Введите целое число от 1 до 32 включительно");
            }
            while (!Validator.IsValidNumber(Console.ReadLine(), out result));

            return result;
        }

        public static void PrintBoard(IBoard board)
        {
            UI.ShowMessage(string.Format("Доска с высотой {0} и шириной {1} :", board.Height, board.Weight));
            for( int indexX = 0; indexX < board.Height; indexX++)
            {
                for(int indexY = 0; indexY < board.Weight; indexY++)
                {
                    if(board[indexX,indexY].Color == Color.Black)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
