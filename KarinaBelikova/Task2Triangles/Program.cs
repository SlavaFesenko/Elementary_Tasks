using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            TriangleCollection triangles = new TriangleCollection();
            do
            {
                Console.Write("Назовите свой треугольник: ");
                string name = Console.ReadLine();
                Console.Write("Введите длину {0} стороны треугольника: ", 1);
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину {0} стороны треугольника: ", 2);
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину {0} стороны треугольника: ", 3);
                double c = Convert.ToDouble(Console.ReadLine());

                #region Validation and Add Triangle To List

                int flag = 0;
                if (a > b + c)
                {
                    flag = 1;
                }
                else if (b > a + c)
                {
                    flag = 2;
                }
                else if (c > a + b)
                {
                    flag = 3;
                }
                else
                {
                    Console.WriteLine("Треугольник существует");

                    // Add triangle to collectioan
                    triangles.Add(new Triangle(name, a, b, c));                   
                }

                if (flag != 0)
                {
                    Console.WriteLine("Треугольник не существует");
                    Console.WriteLine("Сторона {0} длиннее или равна сумме двух других ", flag);
                }

                #endregion
                
                Console.Write("Хотите создать еще один треугольник? ");
                answer = Console.ReadLine();
            } while (answer == "y");

            // Sort triangles descending
            triangles.Sort();
            triangles.Reverse();

            Console.WriteLine();

            Console.WriteLine("======= Triangles list: =======");

            foreach (Triangle triangle in triangles)
            {
                Console.WriteLine(triangle.ToString());
            }

            Console.ReadKey();          
        }
    }
}
