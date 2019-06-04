using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalyzer
{
    public class UI : BaseUI
    {
        public static void ShowInstruction()
        {
            ShowMessage(string.Format("===========TASK 2==========="));
        }

        public static double ReadFromConsoleNumber(string numberEnvelope,string numberSide)
        {
            bool isReaded = false;
            double readedParametr = 0;

            do
            {
                ShowMessage(string.Format("Введите размер {0} параметра для {1} треугольника", numberSide,numberEnvelope));
                if(double.TryParse(Console.ReadLine(),out readedParametr) && Validator.IsValidValue(readedParametr))
                {
                    isReaded = true;
                }
                else
                {
                    ShowError("Неправильный ввод!Введенное не является положительным числом");
                }
            } while (!isReaded);

            return readedParametr;
        }

    }
}
