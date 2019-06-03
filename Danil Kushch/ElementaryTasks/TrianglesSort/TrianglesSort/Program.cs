using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort
{
    class Program
    {

        static void Main(string[] args)
        {
            string questionMessage = "Wanna add another triangle?\n(say 'Y' or 'YES' to do it, or any other key to don't)";
            TriangleCollection myTriangles = new TriangleCollection();

            try
            {
                bool doesAddNewTriangle;
                do
                {
                    DoAlgorithm(ref myTriangles);
                    Console.WriteLine(questionMessage);
                    string userAnswer = Console.ReadLine().ToUpper().Trim();
                    if (userAnswer == "Y" || userAnswer == "YES")
                    {
                        doesAddNewTriangle = true;
                        Console.Clear();
                    }
                    else
                        doesAddNewTriangle = false;
                } while (doesAddNewTriangle);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        #region Method

        public static void DoAlgorithm(ref TriangleCollection myTrianglesList)
        {
            string inputMessage = "Please input the triangle: ";
            string formatMessage = "FORMAT <name>, <sideA>, <sideB>, <sideC>";

            Console.WriteLine($"{inputMessage}\n{formatMessage}");
            string[] myArgs = Console.ReadLine().Trim().Split(',');
            Triangle myTriangle = (Triangle)Validator.ValidatingArgsToTriangle(myArgs).Clone();
            myTrianglesList.Add(myTriangle);
            UI.ConsoleUI.BuildUI(myTrianglesList);
        }

        #endregion
    }
}
