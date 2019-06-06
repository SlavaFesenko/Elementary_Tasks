using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSorting_3
{
    class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            try
            {
                List<Triangle> triangles = CreateList();
                SortTriangles(triangles);
            }
            catch (ArgumentException ex)
            {
                UI.PrintErrorMessage(ex.Message);
                log.Error(ex.Message);
            }
            catch (CantCompareException ex)
            {
                UI.PrintErrorMessage(ex.Message);
                log.Error(ex.Message);
            }

            Console.Read();
        }
        
        private static double[] ReadTriangle(out string name)
        {
            bool isCorrect;
            double[] sides = new double[3];

            do
            {
                string[] args = UI.ReadParameters();
                isCorrect = Validator.Validate(args, out name, out sides, out string message);

                if (!isCorrect)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        UI.PrintErrorMessage(message);
                        log.Error(message);
                    }
                    UI.ShowInstruction();
                }
            } while (!isCorrect);

            return sides;
        }

        private static List<Triangle> CreateList()
        {
            List<Triangle> triangles = new List<Triangle>();
            bool repeat;

            do
            {
                double[] sides = ReadTriangle(out string name);                
                triangles.Add(new Triangle(name, sides[0], sides[1], sides[2]));               
                repeat = UI.ProposeAgain();

            } while (repeat);
            return triangles;
        }

        private static void SortTriangles(List<Triangle> triangles)
        {
            triangles.Sort(new TriangleDescBySquareComparer());
            UI.PrintTriangleList(triangles);
        }
    }
}
