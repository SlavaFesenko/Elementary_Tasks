using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Conerter
{
    public class InputModel
    {
        public int Number { get; private set; }

        public InputModel(int number)
        {
            if (number < -999999999 || number > 999999999)
                throw new ArgumentException("Введенное число не удолетворяет диапазон от -999999999 до 999999999");
            Number = number;
        }

    }
}
