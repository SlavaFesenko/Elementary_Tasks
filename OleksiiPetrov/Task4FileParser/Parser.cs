using System;
using System.IO;
using System.Text;

namespace Task4FileParser
{
    public class Parser
    {
        #region Field
        private string _path;
        #endregion

        #region Ctor
        public Parser(string path)
        {
            _path = path;
        }

        #endregion

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
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    countEntry += GetCountEntryInLine(line.ToString(), searchingString);
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

            using (StreamReader reader = new StreamReader(_path, Encoding.Default)) 
            {
                using (StreamWriter writer = new StreamWriter(tempFileName, true))
                {
                    string line = string.Empty;

                    while((line = reader.ReadLine()) !=null)
                    {
                        countEntry += GetCountEntryInLine(line, searchingString);

                        line = line.Replace(searchingString, replacementString);
                        writer.WriteLine(line);
                    }
                }
            }

            TrySaveFile(countEntry, tempFileName);
        }

        private void TrySaveFile(int countEntry, string tempFileName)
        {
            try
            {
                if (countEntry == 0)
                    throw new ArgumentException("Searching string not found at this text");

                if (countEntry > 0)
                {
                    File.Delete(_path);
                    //change name of tmp file to _path
                    File.Move(tempFileName, _path);
                }
            }
            catch(IOException ex)
            {
                throw new IOException($"File save failed: {tempFileName} \nException: {ex.Message}");
            }
        }

        private int GetCountEntryInLine(string line, string searchingString)
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
