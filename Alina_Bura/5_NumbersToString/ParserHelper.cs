using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToString_5
{
    static class ParserHelper
    {
        public static Dictionary<int, string> InitDictionary(string fileName)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            FileInfo f = new FileInfo(fileName);
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File doesn't exists!");
            }
            using (FileStream fs = f.OpenRead())
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split('-');
                        dictionary.Add(int.Parse(data[0]), data[1]);
                    }
                }
            }
            return dictionary;
        }
    }
}
