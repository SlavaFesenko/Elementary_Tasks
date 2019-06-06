using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Square
{
    public class Validator
    {       
        public static bool IsCorrectArgs7Task(string[] args, out int number)
        {
            bool isCorrect = false;
            number = int.Parse(args[1]);
            if (number > 0)
                isCorrect = true;

            return isCorrect;
        }

        public static bool IsPozitiveNumber(int number)
        {
            if (number > 0)
                return true;

            return false;
        }
    }
}
