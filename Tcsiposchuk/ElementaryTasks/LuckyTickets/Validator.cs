using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTickets
{
    public class Validator
    {
        #region Methods 

        static public bool IsPathValid(string path)
        {
            return File.Exists(path);
        }
        static public bool IsArgumentsValid(List<string> arguments, out string message)
        {
            message = "Файл содержит ошибки\n";
            bool isFirstArgValid = arguments[0].ToUpper() == "MOSKOW" || arguments[0].ToUpper() == "PITER";
            bool isSecondArgValid = int.TryParse(arguments[1],out int x) && x >= 1;
            bool isThirdArgValid = int.TryParse(arguments[2], out int y) && y >= 1 && x <= y;
            if(isFirstArgValid == false)
            {
                message += "Неправильный тип билета\n";
            }
            if (isSecondArgValid == false)
            {
                message += "Начало диапазона не подходит. Оно должно быть больше 0 \n";
            }
            if (isThirdArgValid == false)
            {
                message += "Конец диапазона не подходит. Он должен быть больше/равен началу и 1\n";
            }



            return isFirstArgValid && isSecondArgValid && isThirdArgValid;
        }
        
        #endregion Methods
    }
}
