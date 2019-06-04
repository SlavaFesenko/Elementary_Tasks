using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class BaseUI
    {
        /// <summary>
        /// Выводит любую последовательность через запятую в консоль
        /// </summary>
        /// <typeparam name="T">любой тип реализующий ToString()</typeparam>
        /// <param name="enumerable"></param>
        public static void PrintIEnumerable<T>(IEnumerable<T> enumerable)
        {
            string print = String.Join(",", enumerable);
            ShowResult(print);

        }
        /// <summary>
        /// Выводит переданную строку на консоль, без перехода на новую строку
        /// </summary>
        /// <param name="message">Строка содержащая форматирующие последовательности для корректного отображения</param>
        public static void ShowError(string message)
        {
            Console.Write(message);
        }
        /// <summary>
        /// Выводит сообщения консоль о неверности пути к файлу и приводит пример корректного пути
        /// </summary>
        protected static void ShowInstructionWrongPath()
        {
            Console.WriteLine("Ошибка, по указанному пути файла не существует");
            Console.WriteLine("Введите еще раз, пример - D:\\\\Папка\\\\Filename.txt ");
        }
        /// <summary>
        /// Показывает сообщение об результате программы пользователю
        /// </summary>
        /// <param name="message"></param>
        public static void ShowResult(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Показывает сообщение пользователю
        /// </summary>
        /// <param name="message"></param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Ожидает ввод пользователем строки
        /// </summary>
        /// <returns>Возвращает true, если пользователем была введено y/Yes (без учета регистра) и false в ином случае</returns>
        public static bool AskUserAboutEndProgram()
        {
            bool isEndSession = true;
            string response = Console.ReadLine();
            response = response.ToUpperInvariant();
            if (response == "YES" || response == "Y")
            {
                isEndSession = false;
            }
            

            return isEndSession;
        }
    }
}
