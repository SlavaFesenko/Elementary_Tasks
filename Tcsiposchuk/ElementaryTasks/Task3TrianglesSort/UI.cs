using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TrianglesSort
{
    public class UI : BaseUI
    {
        internal static void ShowInstruction()
        {
            ShowMessage("Это третье задание.Производитсяя вывод треугольников в порядке убывания их площади.\n" +
                "После добавления каждого нового треугольника программа спрашивает, хочет ли пользователь добавить ещё один.\n" +
                "Если пользователь ответит “y” или “yes” (без учёта регистра),\nпрограмма попросит ввести данные для ещё одного треугольника,\n" +
                "в противном случае – выводит результат в консоль.");
            
        }

        internal static string ReadName()
        {
            return Console.ReadLine();
        }

        internal static double ReadParametr()
        {
            string input;

            do
            {
                ShowMessage("Введите положительное число (пример: 12,5 или 10 или 5)");
                input = Console.ReadLine();
            }
            while (!Validator.IsNumber(input));

            return Convert.ToDouble(input);
        }

        public static void PrintTriangles(IEnumerable<Triangle> triangles)
        {
            ShowMessage("============= Список треугольников: ===============");
            foreach(var tr in triangles)
            {
                ShowMessage(tr.ToString());
            }
        }


    }
}
