using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7Square
{
    public class Validator
    {       
        public static bool HasParam(string[] args)
        {
            return (args.Length == 1);                 
        }

        public static bool IsPozitiveNumber(int number)
        {
            return (number > 0);
        }
    }
}
