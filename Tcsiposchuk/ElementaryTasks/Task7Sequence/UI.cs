using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Sequence
{
    class UI : BaseUI
    {
        public static int GetNaturalNumberFromConsole()
        {
            bool isReaded = false;
            int result = 0;

            while (!isReaded)
            {
                UI.ShowMessage("Введите целое натуральное число до 2147483647");
                isReaded = Int32.TryParse(Console.ReadLine(), out result);
                if (isReaded)
                {
                    isReaded = result > 0;
                }
                else
                {
                    UI.ShowError("Вы ввели не целое число до 2147483647\n");
                    continue;
                }
                if (!isReaded)
                {
                    UI.ShowError("Вы ввели не натуральное число \n");
                }
            }

            return result;

        }

        public  static void PrintResult(int number, IEnumerable<int> enumerable)
        {
            ShowResult(String.Format("Ряд натуральных чисел, квадрат которых меньше {0} ", number));
            PrintIEnumerable(enumerable);
        }

        public static void ShowInstruction()
        {
            Console.WriteLine("Программа выводит ряд натуральных чисел через запятую, квадрат которых меньше заданного n.");
        }
    }
}
