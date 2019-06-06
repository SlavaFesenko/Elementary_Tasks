using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Parser
{
    public class InputModel
    {
        public string FindThisString { get; set; }
        public string Path { get; set; }

        public string ReplaceThisString { get; set; }

        public WorkMode WorkMode { get; set; }

        public InputModel(string findString, string path)
        {
            WorkMode = WorkMode.Count;
            FindThisString = findString;
            Path = path;
        }

        public InputModel(string replaceString, string findString, string path)
        {
            WorkMode = WorkMode.Replace;
            FindThisString = findString;
            ReplaceThisString = replaceString;
            Path = path;
        }
    }
}
