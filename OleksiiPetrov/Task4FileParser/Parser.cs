using System;
using System.IO;
using System.Text;

namespace Task4FileParser
{
    public class Parser
    {
        private string _path;

        public Parser(string path)
        {
            _path = path;
        }

        #region Methods
        /// <summary>
        /// Get count entries string in the text 
        /// </summary>
        /// <param name="searchingString">searching string</param>
        /// <returns>count entries</returns>
        public virtual int GetCountEntries(string searchingString)
        {
            int countEntry = 0;

            using (StreamReader reader = new StreamReader(_path, Encoding.Default))
            {
                // more effective than string
                StringBuilder line = new StringBuilder();

                //методи стринга в место getcount enrtyсерч
                while ((line.Append(reader.ReadLine())) != null)
                {
                    if (line.Length == 0)
                        break;
                    countEntry += GetCountEntry(line.ToString(), searchingString);
                    line.Clear();
                }
            }
            
            return countEntry;
        }
        
        /// <summary>
        /// Make a replacement searching string to other:
        /// Create tmp file in the current directory, read base file by lines,
        /// and write to tmp. If entry string => replace. 
        /// After all content is swap(tmp,base) and delete tmp file. 
        /// </summary>
        /// <param name="searchingString">searching string</param>
        /// <param name="replacementString">string for replace</param>
        public virtual void ReplaceAll(string searchingString, string replacementString)
        {
            int countEntry = 0;

            string tempFileName = System.IO.Path.GetRandomFileName() + ".txt";

            using (File.Create(tempFileName)) { }
            
            using (StreamWriter writer = new StreamWriter(tempFileName))
            {
                using (StreamReader reader = new StreamReader(_path, Encoding.Default))
                {
                    // more effective than string
                    StringBuilder line = new StringBuilder();
                    
                    while ((line.Append(reader.ReadLine())) != null)
                    {
                        if (line.Length == 0)
                            break;
                        countEntry += GetCountEntry(line.ToString(), searchingString);
                        if (countEntry > 0)
                        {
                            line = line.Replace(searchingString, replacementString);
                            writer.WriteLine(line);
                            //Console.WriteLine(line);
                        }
                        line.Clear();
                    }
                    
                }
            }
            if (countEntry == 0)
            {
                TrySaveFile(countEntry, tempFileName);
                throw new ArgumentException("Searching string not found at this text");
            }

            TrySaveFile(countEntry, tempFileName);
        }

        private void TrySaveFile(int countEntry, string tempFileName)
        {
            try
            {
                if (countEntry > 0)
                    File.Replace(tempFileName, _path, null);//rename and deletede path
                if (countEntry == 0)
                    return;
            }
            catch(IOException ex)
            {
                throw new IOException($"File save failed: {tempFileName} \nException: {ex.Message}");
            }
        }

        private static int GetCountEntry(string line, string searchingString)
        {
            int startIndex = 0;
            int countEntry = 0;
            do
            {
                startIndex = line.IndexOf(searchingString, startIndex);
                if (startIndex > -1)
                {
                    countEntry++;
                    startIndex++;
                }
            } while (startIndex > -1);

            return countEntry;
        }
    }

    #endregion
}
