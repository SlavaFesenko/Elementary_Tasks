using CommonLibrary;
using System;
using System.Collections.Generic;

namespace Task3TrianglesSort
{
    public class Controller : BaseController
    {
        private List<Triangle> Triangles = new List<Triangle>();
        public void Run()
        {
            InputModel input = null;
            while (input == null)
            {
                try
                {
                    input = GetInputModelFromUI();
                }
                catch (ArgumentException ex)
                {
                    UI.ShowMessage(ex.Message);
                    input = null;
                }

            }
            Triangles.Add(new Triangle(input));
            IsSuccessful = UI.AskUserAboutEndProgram();
        }

        public void ShowResult()
        {
            Triangles.Sort();
            UI.PrintTriangles(Triangles);
        }

        private InputModel GetInputModelFromUI()
        {
            UI.ShowMessage("Нужно задать имя треугольника.");
            string name = UI.ReadName();
            UI.ShowMessage("Нужно задать первую сторону треугольника.");
            double first = UI.ReadParametr();
            UI.ShowMessage("Нужно задать вторую сторону треугольника.");
            double second  = UI.ReadParametr();
            UI.ShowMessage("Нужно задать третью сторону треугольника.");
            double third = UI.ReadParametr();
            return new InputModel(name, first, second, third);
        }
    }
}
