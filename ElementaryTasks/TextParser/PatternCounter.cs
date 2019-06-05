using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextParser
{
    public class PatternCounter:IParserMode
    {
        public int Counter { get; private set; }

        #region Methods

        public void DoAlgorithm(string[] args)
        {
            string path = args[0];
            string pattern = args[1];
            List<string> text = ReadFromFile(path);

            foreach (string line in text)
            {
                if (line.Contains(pattern))
                    Counter++;
            }          
        }

        private List<string> ReadFromFile(string path)
        {
            List<string> text = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string buffer = sr.ReadLine();

                while (buffer != null)
                {

                    text.Add(buffer);

                    buffer = sr.ReadLine();
                }
            }

            return text;
        }

        #endregion
    }
}
