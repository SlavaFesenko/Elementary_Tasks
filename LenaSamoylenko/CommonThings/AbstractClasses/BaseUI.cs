using System;
using System.Collections.Generic;
using System.Text;

namespace CommonThings
{
    public abstract class BaseUI : IUA
    {
        public enum TaskNumber { Task1 = 1, Task2 = 2, Task3 = 3, Task4 = 4, Task5 = 5, TAsk6 = 6, Task7 = 7, Task8 = 8 }

        protected void SetConsoleSize(int height, int wight)
        { }


        public void CheckForExit(string message)
        {
            if (message != null)
            {
                Environment.Exit(0);
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public abstract string CalculateOK();
        public abstract string PrintIntoConsole();
    }



}
