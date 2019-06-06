using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Conerter
{
    public class UI : BaseUI
    {
        #region Methods

        public static void ShowInstruction()
        {
            ShowMessage("Преобразовывает целое число в прописной вариант: 12 – twelve. Допустимый диапазон от -999999999 до +999999999");
        }
        public static void ShowConvert(int number, string samplesInWords)
        {
            ShowMessage(String.Format("Число {0} прописью будет {1}", number, samplesInWords));
        }
        internal static int ReadParametr()
        {
            string input;

            do
            {
                ShowMessage("Введите целое число от -999999999 до +999999999 включительно");
                input = Console.ReadLine();
            }
            while (!Validator.IsNumber(input));

            return Convert.ToInt32(input);
        }

        #endregion

    }
}
