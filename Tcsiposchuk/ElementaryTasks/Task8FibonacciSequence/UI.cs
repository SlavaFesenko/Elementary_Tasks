using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8FibonacciSequence
{
    class UI : BaseUI
    {
        public static int GetNaturalNumberFromConsole(int y = 0)
        {
            bool isReaded = false;
            int result = 0;

            while (!isReaded)
            {
                UI.ShowMessage(string.Format("Введите целое натуральное число от {0} до 2147483647", y));
                isReaded = Int32.TryParse(Console.ReadLine(), out result);
                if (isReaded)
                {
                    isReaded = result > y;
                }
                else
                {
                    UI.ShowError("Вы ввели не целое число до 2147483647\n");
                    continue;
                }
                if (!isReaded)
                {
                    UI.ShowError(string.Format("Вы ввели число меньше допустимого ({0}) \n", y));
                }
            }

            return result;

        }

        public  static void PrintResult(int [] number, IEnumerable<int> enumerable)
        {
            ShowResult(String.Format("Ряд чисел фибоначчи, в диапазоне от {0} до {1} ", number[0], number[1]));
            PrintIEnumerable(enumerable);
        }

        public static void ShowInstruction()
        {
            Console.WriteLine("Программа выводит числа фибоначчи через запятую, которые находятся в указаном положительном диапазоне.");
        }
    }
}
