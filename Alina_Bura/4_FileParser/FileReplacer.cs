using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileParser_4
{
    static class FileReplacer
    {
        internal static void ReplaceString(string fileName, string target, string substitute)
        {
            using (StreamReader sr = new StreamReader(fileName))
            using (StreamWriter sw = new StreamWriter("new.txt"))
            {
                int readSize = 1000 + target.Length;
                char[] buffer = new char[readSize + target.Length - 1];
                sr.Read(buffer, 0, readSize);
                Replace(buffer, sw, target, substitute, 0, readSize);
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < target.Length - 1; i++)  
                    {
                        buffer[i] = buffer[readSize + i + 1];
                    }
                    sr.Read(buffer, target.Length, readSize);
                    Replace(buffer, sw, target, substitute, 0, buffer.Length);
                }
            }
        }

        private static void Replace(char[] buffer, StreamWriter sw, string target, string substitute, int startIndex, int finishIndex)
        {
            for (int i = startIndex; i < finishIndex; i++)
            {
                if (HasMatch(buffer, i, target))
                {
                    i += target.Length - 1;
                    sw.Write(substitute);
                    continue;
                }

                sw.Write(buffer[i]);
            }
        }

        private static bool HasMatch(char[] buffer, int startIndex, string target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (buffer[startIndex + i] != target[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
