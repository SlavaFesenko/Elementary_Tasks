using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser_4
{
    class FileFinder
    {
        public static int GetCount(string fileName, string target)
        {
            int count = 0;

            using (StreamReader sr = new StreamReader(fileName))
            {
                int readSize = 1000 + target.Length;
                char[] buffer = new char[readSize + target.Length - 1];
                sr.Read(buffer, 0, readSize);

                count += FindMatch(buffer, target, 0, readSize);
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < target.Length - 1; i++)
                    {
                        buffer[i] = buffer[readSize + i + 1];
                    }
                    sr.Read(buffer, target.Length, readSize);
                    count += FindMatch(buffer, target, 0, buffer.Length);
                }
            }

            return count;
        }

        private static int FindMatch(char[] buffer, string target, int startIndex, int finishIndex)
        {
            int count = 0;
            for (int i = startIndex; i < finishIndex; i++)
            {
                if (HasMatch(buffer, i, target))
                {
                    count++;
                    i += target.Length - 1;
                    continue;
                }
            }
            return count;
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
