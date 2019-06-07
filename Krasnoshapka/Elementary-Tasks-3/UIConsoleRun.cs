using System;
using System.Collections.Generic;
using NLog;

namespace ElementaryTasks3
{
    static class UIConsoleRun
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private const int COMMAND_LINE_ARGS = 0;
        private const int ARGS_FOR_TRIANGLE=4;

        /// <summary>
        /// Method to run applications
        /// </summary>
        public static void BuildUI(string[] args)
        {
            if (args.Length == COMMAND_LINE_ARGS)
            {
                bool Finish = true;

                List<Triangle> trianglesList = new List<Triangle>();

                #region MainFunctional

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

                        success = Parsing(input, out triangleName, out firstTriangleSide, out secondTriangleSide, out thirdTriangleSide, success);

                        if (success)
                        {
                            Triangle triangle = Triangle.TriangleInitialize(triangleName, firstTriangleSide, secondTriangleSide, thirdTriangleSide);

                            trianglesList.Add(triangle);
                            trianglesList.Sort(new TrianglesCompare());

                            ShowList(trianglesList);

                            Finish = Repeat();
                        }
                        else
                        {
                            Finish = true;
                            Console.WriteLine("Please enter numbers as triangle parameters");
                            logger.Error("Not numbers was entered!");
                        }
                    }
                    else
                    {
                        Finish = true;
                        Console.WriteLine("Argument Error: wrong count of arguments!");
                        logger.Error("Wrong count of arguments!");
                    }

                } while (Finish);

                #endregion

            }
            else
            {
                Instruction();
            }
        }

        #region OtherMethods

        /// <summary>
        /// Method for parsing input
        /// </summary>
        private static bool Parsing(string[] input, out string triangleName, out float firstTriangleSide, out float secondTriangleSide, out float thirdTriangleSide, bool success)
        {
            triangleName = input[0];
            success &= float.TryParse(input[1], out firstTriangleSide);
            success &= float.TryParse(input[2], out secondTriangleSide);
            success &= float.TryParse(input[3], out thirdTriangleSide);
            return success;
        }

        /// <summary>
        /// Method for printing triangle list.
        /// </summary>
        private static void ShowList(List<Triangle> trianglesList)
        {
            Console.WriteLine("============= Triangles list: ===============");
            foreach (Triangle item in trianglesList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void Instruction()
        {
            Console.WriteLine("Arguments are set inside program, please don`t input any additional parameters!");
        }

        /// <summary>
        /// Checking for answer to continue execution of program or not
        /// </summary>
        /// <returns>Decision</returns>
        private static bool Repeat()
        {
        Console.WriteLine("To repeat type y/Y or yes/YES:");
        string answer = Console.ReadLine().ToLower();
        return answer == "y" || answer == "yes";
        }

        #endregion

    }
}
