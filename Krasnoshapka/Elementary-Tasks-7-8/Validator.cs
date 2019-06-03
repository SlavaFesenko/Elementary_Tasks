using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_7_8
{
    class Validator
    {
        public static bool ValidFibonacci(int leftBorder, int rightBorder)
        {
            if (leftBorder>0 && rightBorder>0)
            {
                if (leftBorder< rightBorder)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException("Left number must be smaller than right");
                }
            }
            else
            {
                throw new ArgumentException("Nambers must be natural");
            }
        }

        public static bool ValidSquare(int rightBorder)
        {
            bool result = false; 
            if (rightBorder > 1)
            {
                result=true;
            }
            return result;
        }

        public static int Parsed(string value)
        {
            int number;

            bool success = Int32.TryParse(value, out number);

            if (success)
            {
                return number;
            }
            else
            {
                throw new FormatException("Please enter numbers");
            }

        }
        
        public static void Parsed(string firstValue, string secondValue, ref int firstNumber, ref int secondNumber)
        {
            bool success = Int32.TryParse(firstValue, out firstNumber);
            success &= Int32.TryParse(secondValue, out secondNumber);

            if (!success)
            {
                throw new FormatException("Please enter numbers");
            }
        }

    }
}
