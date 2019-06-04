using System;
using System.Collections.Generic;
using System.Text;

namespace CommonThings
{
    public abstract class BaseUI : IUI
    {
        protected void SetConsoleSize(int height, int wight)
        { }


        public void CheckForExit(string message)
        {
            if (message != null)
            {
                Exit();
            }
        }
        public void Exit()
        {
            Console.WriteLine("The application will be closed");
            Environment.Exit(0);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public abstract string CalculateOK();
        public abstract string PrintIntoConsole();
    }



}
