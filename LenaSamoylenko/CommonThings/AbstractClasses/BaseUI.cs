using System;
using System.Collections.Generic;
using System.Text;

namespace CommonThings
{
    public abstract class BaseUI:IUA
    {
        protected void SetConsoleSize(int height, int wight)
        { }


        public void CheckForExit(string message)
        {
            if (message!=null)
            {
                Environment.Exit(0);
            }
        }

        public abstract string CalculateOK();
        public abstract string PrintIntoConsole();
    }



}
