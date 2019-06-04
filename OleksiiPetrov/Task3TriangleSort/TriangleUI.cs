using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TriangleSort
{
    class TriangleUI
    {
        //private string INPUT_MESSAGE = "Please in"
        private bool _doesNewTriangle = false;
        TriangleCollection triangles;
        public TriangleUI()
        {
            triangles = new TriangleCollection();
            Show();
        }
        //TODO: Add instruction and cach exceptions
        private void Show()
        {
            do
            {
                Console.WriteLine("Please input the triangle:");
                string[] inputValues = Console.ReadLine().Trim(' ').Split(','); //TODO: ADD check values

                Triangle tmpTriangle = new Triangle(inputValues[0], Double.Parse(inputValues[1]), Double.Parse(inputValues[2]), Double.Parse(inputValues[3]));
                triangles.AddTriangle(tmpTriangle);
                triangles.SortBySquare();

                Console.WriteLine("============= Triangles list: ===============");
                Console.WriteLine(triangles);

                Console.WriteLine("If you whant to add another triangle, please input 'Y' or 'YES' to do it.");
                string userAnswer = Console.ReadLine().ToUpper().Trim();
                if (userAnswer == "Y" || userAnswer == "YES")
                {
                    _doesNewTriangle = true;
                    Console.Clear();
                }
            } while (_doesNewTriangle);
        }
    }
}
