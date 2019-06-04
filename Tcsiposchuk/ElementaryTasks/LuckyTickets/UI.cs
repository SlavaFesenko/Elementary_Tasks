using CommonLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    public class UI : BaseUI
    {
        #region Methods

        public static void ShowInstruction()
        {
            ShowMessage("============Task 6============");
            ShowMessage("Вам нужно ввести путь к файлу, в котором первая строка тип билета(Moskow/Piter)," +
                " вторая и третья - начало и конец диапазона билетов(только числа больше 1 и меньше 100000)");
            ShowMessage("Пример : D:\\\\Filename.txt ");
        }
        public static string GetPathFromConsole()
        {
            string path = Console.ReadLine();
            bool isPathValid = Validator.IsPathValid(path);

            while (!isPathValid)
            {
                ShowInstructionWrongPath();
                path = Console.ReadLine();
                isPathValid = File.Exists(path);
            }

            return path;
        }
        
        public static void ShowInformationAboutAnalyzator(string type, string startRange, string endRange)
        {
            Console.WriteLine(string.Format("Подсчет счастливых билетов в диапазоне от {1} до {2} введется по {0} способу", type, startRange, endRange));
        }
        public static void ShowCountLuckyTickets(int countLuckyTickets)
        {
            ShowMessage(string.Format("В заданном диапазоне находится {0} счастливых билетов", countLuckyTickets));
        }

        #endregion

    }
}
