using System;

namespace Task7_8Sequences
{
    public class Validator
    {      
        public static bool IsPozitiveNumber(int number)
        {           
            if (number > 0)            
                return true;

            return false;           
        }

        public static bool IsCorrectRange(int lowLimit, int upLimit)
        {
            if (lowLimit < upLimit)
                return true;

            return false;
        }

        public static bool IsCorrectArgs7Task(string[] args, out int[] paramsTask7)
        {   
            paramsTask7 = Array.ConvertAll(args, int.Parse);
            if (paramsTask7[0] == 7 && paramsTask7[1] > 0)
                return true;

            return false;
        }

        public static bool IsCorrectArgs8Task(string[] args, out int[] paramsTask8)
        {                     
            paramsTask8 = Array.ConvertAll(args, int.Parse);
            if (paramsTask8[0] == 8 && paramsTask8[1] < paramsTask8[2])
                return true;

            return false;
        }
    }
}
