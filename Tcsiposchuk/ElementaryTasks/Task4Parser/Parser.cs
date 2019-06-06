using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4Parser
{
    public class Parser
    {
        public string FindThisString { get; set; }
        public string Path { get; set; }

        public string ReplaceThisString { get; set; }

        public WorkMode WorkMode { get; set; }

        public Parser(string findString, string path)
        {
            WorkMode = WorkMode.Count;
            FindThisString = findString;
            Path = path;
        }

        public Parser(string replaceString, string findString, string path)
        {
            WorkMode = WorkMode.Replace;
            FindThisString = findString;
            ReplaceThisString = replaceString;
            Path = path;
        }

        public Parser(InputModel model)
        {
            WorkMode = model.WorkMode;
            FindThisString = model.FindThisString;
            ReplaceThisString = model.ReplaceThisString;
            Path = model.Path;
        }
        
        public int Execute()
        {
            int result = -1;

            if(WorkMode == WorkMode.Replace)
            {
                result = ReplaceString();
            }
            if (WorkMode == WorkMode.Replace)
            {
                result = CountString();
            }

            return result;
        }

        private int ReplaceString()
        {
            int count;
            string str;
            using (StreamReader strReader = new StreamReader(Path))
            {
                str = strReader.ReadToEnd();
                string str1 = str;
                count = (str1.Length - str1.Replace(FindThisString, "").Length) / FindThisString.Length;
                str.Replace(FindThisString, ReplaceThisString);
            }
            using (StreamWriter strWriter = new StreamWriter(Path, false))
            {
                strWriter.Write(str);
            }
            return count;
        }
        
        private int CountString()
        {
            int count;
            using (StreamReader strReader = new StreamReader(Path))
            {    
                string str = strReader.ReadToEnd();
                count = (str.Length - str.Replace(FindThisString, "").Length) / FindThisString.Length;
            }
            return count;
        }
            


        
    }
}
