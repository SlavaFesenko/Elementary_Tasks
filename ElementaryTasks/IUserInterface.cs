using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static interface IUserInterface
{
    static void ShowErrorMessage(Exception e);
    static void Display<T>(T programResult);
}
