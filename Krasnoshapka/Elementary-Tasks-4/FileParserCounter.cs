using System.Text.RegularExpressions;
using System.IO;

namespace Elementary_Tasks_4
{
    class FileParserCounter : FileParser
    {
        public int Count { get; set; }

        public FileParserCounter(string filepath, string pattern) : base(filepath, pattern)
        {
            Count = 0;
        }

        public override void FileParse()
        {
            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = (streamReader.ReadLine());
                    Count += new Regex($@"{Pattern}").Matches(line).Count;
                }
            }
        }
    }
}
