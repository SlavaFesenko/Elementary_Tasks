using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;

namespace Task3_TriangleSorting
{
    class Logic
    {
        public static char DecisionToContinue()
        {
            char result = 'n';

            Console.WriteLine("Are you want to continue? (y/n or yes/no)");
            string continueResult = Validator.ChangeRegistrToLowwer(Console.ReadLine());
            if (continueResult == "y" || continueResult == "yes")
            {
                result = 'y';
            }

            return result;
        }

        internal static Triangle GenerateNewTriangle(string dataFromUser, out bool result)
        {
            List<string> data;
            Triangle triangle = null;
            result = false;
            int parameterCount = 4; //means that in future could be rectangle 

            bool continueOperation = Validator.RowParsing(dataFromUser, parameterCount, out data);

            if (continueOperation == true)
            {
                double[] numberToDouble = new double[3];
                bool numberToDoubleIsPosible = Validator.VarTypeCheck(data[1], data[3], data[5], out numberToDouble);

                if (numberToDoubleIsPosible == true)
                {
                    result = true;
                    triangle = new Triangle(data[0], numberToDouble[0], numberToDouble[1], numberToDouble[2],
                        data[2], data[4], data[6]);
                }
            }
            return triangle;
        }

    }
}
