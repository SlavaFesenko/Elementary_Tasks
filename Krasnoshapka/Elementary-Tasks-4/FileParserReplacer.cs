using System.Text.RegularExpressions;
using System.IO;

namespace Elementary_Tasks_4
{
    class FileParserReplacer : FileParser
    {
        public string StringToReplace { get; set; }

        public FileParserReplacer(string filepath, string pattern, string stringToReplace)
            : base(filepath, pattern)
        {
            StringToReplace = stringToReplace;
        }

        public override void FileParse()
        {
            string tempFileName = Path.GetTempFileName();
            using (StreamReader streamRead = new StreamReader(FilePath))
            {
                using (StreamWriter streamWrite = new StreamWriter(tempFileName))
                {
                    while (!streamRead.EndOfStream)
                    {
                        Regex regex = new Regex($@"{Pattern}");
                        streamWrite.WriteLine(regex.Replace(streamRead.ReadToEnd(), StringToReplace));
                    }
                    streamWrite.Close();
                    streamRead.Close();
                }
            }
            File.Replace(tempFileName, FilePath, null);
        }
    }
}
