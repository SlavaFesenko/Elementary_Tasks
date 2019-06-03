using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_3
{
    static class UIConsole
    {
        private const int COMMAND_LINE_ARGS = 0;
        private const int ARGS_FOR_TRIANGLE=4;

        public static void BuildUI(string[] args)
        {
            List<Triangle> trianglesList = new List<Triangle>();

            if (args.Length == COMMAND_LINE_ARGS)
            {
                bool Finish = true;

                do
                {
                    Finish = false;
                    Console.WriteLine("Enter name and sides for a new triangle:");
                    string[] input = Console.ReadLine().Split(new char[] { ' ', ',' });

                    if (input.Length == ARGS_FOR_TRIANGLE)
                    {
                        string triangleName;
                        float firstTriangleSide;
                        float secondTriangleSide;
                        float thirdTriangleSide;
                        bool success = true;

                        triangleName = input[0];
                        success &= float.TryParse(input[1], out firstTriangleSide);
                        success &= float.TryParse(input[2], out secondTriangleSide);
                        success &= float.TryParse(input[3], out thirdTriangleSide);
                        if (success)
                        {
                            Triangle triangle = Triangle.TriangleInitialize(triangleName, firstTriangleSide, secondTriangleSide, thirdTriangleSide);
                            trianglesList.Add(triangle);
                            trianglesList.Sort(new TrianglesCompare());
                            Console.WriteLine("============= Triangles list: ===============");
                            foreach (Triangle item in trianglesList)
                            {
                                Console.WriteLine(item.ToString());
                            }

                            Finish = Repeat();
                        }
                        else
                        {
                            throw new FormatException("Please enter numbers as triangle parameters");
                        }
                    }
                    else
                    {
                        throw new ArgumentException(" Not enough parameters for building triangle!");
                    }

                } while (Finish);

            }
            else
            {
                Instruction();
            }
        }


        private static void Instruction()
        {
            Console.WriteLine("Arguments are set inside program, please don`t input any additional parameters!");
        }


        private static bool Repeat()
        {
        Console.WriteLine("To repeat type y/Y or yes/YES:");
        string answer = Console.ReadLine().ToLower();
        return answer == "y" || answer == "yes";
        }
        
    }
}
