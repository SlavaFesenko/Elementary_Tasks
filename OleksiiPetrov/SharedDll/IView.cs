using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDll
{
    public interface IView
    {
        void ShowErrorMessage(string text);
        void ShowInstruction(string text);
        void ShowResult(string text);
        string[] ReInput();
    }
}
