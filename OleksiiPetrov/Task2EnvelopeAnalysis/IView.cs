using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalysis
{
    public interface IView
    {
        void ShowErrorMessage(string text);
        void ShowInstruction(string text);
        void ShowResult(string text);
        string[] ReInput();
    }
}
