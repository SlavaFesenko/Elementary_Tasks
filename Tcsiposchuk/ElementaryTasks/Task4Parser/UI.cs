using CommonLibrary;
using System;

namespace Task4Parser
{
    public class UI : BaseUI
    {
        public static void ShowInstruction()
        {
            ShowMessage("Имеет 2 режима работы : подсчет строки или замены указаной строки в указаном файле." +
                " Для первого режима укажите 2 параметра(путь и строка), для 2го укажите путь строку строкудлязамены");
        }

        internal static string[] GetParamsFromConsole()
        {
            UI.ShowInstructionWrongPath();
            string[] args = Console.ReadLine().Split(' ');
            return args;
        }

        public static void ShowReturn(WorkMode mode, int count )
        {
            if(mode == WorkMode.Replace)
            {
                ShowMessage(String.Format("Было заменено {0} строк", count));
            }
            if (mode == WorkMode.Count)
            {
                ShowMessage(String.Format("Было найдено {0} строк", count));
            }
        }
    }
}
