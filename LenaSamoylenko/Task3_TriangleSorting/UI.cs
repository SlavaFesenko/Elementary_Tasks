using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;

namespace Task3_TriangleSorting
{
    class UI : BaseUI
    {
        private string row;
        private TriangleList _triangles = new TriangleList();

        public char DecisionToContinueProgramm { get => Logic.DecisionToContinue(); }
        public string Row { get => row; set => row = value; }


        public UI()
        {
            Console.WriteLine("Hello in task 3\n");
        }



        public void Print()
        {
            _triangles.Print();
        }

        public override string CalculateOK()
        {
            Wrapper.GetCycle();
        }

        public override string PrintIntoConsole()
        {
            throw new NotImplementedException();
        }
    }

    public class Wrapper
    {
        private static Dictionary<int, string> _answer = new Dictionary<int, string>
        {
            [1] = "Y",
            [2] = "YES"
        };

        public static void GetCycle()
        {
            bool isContinue = true;

            while (isContinue == true)
            {
                Console.WriteLine();
                string getAnswer = (Console.ReadLine()).ToUpper();
                isContinue = (getAnswer == _answer[1] || getAnswer == _answer[2]) ? AddTriangleToCollection() : false;
            }
        }

        public static bool AddTriangleToCollection()
        {
            bool result = false;
            Triangle triangle = null;

            Console.WriteLine("Put your data in format <name>, <size1>, <size2>, <size3>");
            string row = Console.ReadLine();

            triangle = Logic.GenerateNewTriangle(row, out result);
            if (result == true)
            {
                _triangles.Add(triangle);
            }

            return result;
        }
    }
}
