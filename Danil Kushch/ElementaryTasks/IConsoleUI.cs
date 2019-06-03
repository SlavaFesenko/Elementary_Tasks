using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IConsoleUI
{
    void ShowErrorMessage(Exception e);
    void Display<T>(T programResult);
}
