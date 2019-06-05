using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TextParser
{
    public class PatternReplacer:IParserMode, IEnumerable<string>
    {
        public List<string> ChangedText { get; private set; }

        #region Methods

        public void DoAlgorithm(string[] args)
        {
            string path = args[0];
            string replacementPattern = args[1];
            string substitutePattern = args[2];
            ChangedText = ReadFromFile(path);

            for (int i = 0; i < ChangedText.Count; i++)
            {
                if (ChangedText[i].Contains(replacementPattern))
                    ChangedText[i] = ChangedText[i].Replace(replacementPattern, substitutePattern);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)ChangedText).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)ChangedText).GetEnumerator();
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
