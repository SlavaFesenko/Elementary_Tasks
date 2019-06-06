using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace Task5IntToString
{
    class Program
    {
        static IView _view = new ConsoleView();
        static void Main(string[] args)
        {
            Run(args);
        }

        public static void Run(string[] args)
        {
            try
            {
                _view.ShowResult(GetConvertMessage(Validator.Validate(args)));
            }
            catch (ArgumentNullException ex)
            {
                _view.ShowErrorMessage(ex.Message);
                _view.ShowInstruction(Instruction());
            }
            catch (ArgumentException ex)
            {
                _view.ShowErrorMessage(ex.Message);
                _view.ShowInstruction(Instruction());
            }

        }

        public static string Instruction()
        {
            return $"Программа преобразовывает целое число в прописной вариант: (Пример: 12 – двенадцать)." +
                $" Программа запускается через вызов главного класса с параметрами." +
                $"Если вы хотите продолжить работу, запустите программу передав в аргумент целое число.";
        }

        public static string GetConvertMessage(int number)
        {
            return $"Your number {number} was converted to string: {Converter.Convert(number)}";
        }
    }
}
