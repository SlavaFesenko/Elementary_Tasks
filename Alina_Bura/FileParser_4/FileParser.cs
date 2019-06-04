using System;
using System.Collections.Generic;
using System.IO;

namespace FileParser_4
{
    internal class FileParser
    {
        internal static int GetCountOfString(string fileName, string targetString)
        {
            return 0;
        }

        internal static void ReplaceString(string fileName, string target, string substitute)
        {
            using (StreamReader sr = new StreamReader(fileName))
            using (StreamWriter sw = new StreamWriter(fileName + "Temp"))
            {
                Replace(sr, sw, target, substitute);
            }
        }

        private static void Replace(StreamReader sr, StreamWriter sw, string target, string substitute)
        {
            int readSize = Math.Max(1024, 2 * target.Length);
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

        private static void Replace(char[] buffer, StreamWriter sw, string target, string substitute, int startIndex, int count)
        {
            for (int i = startIndex; i < count; i++)
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
             
        }
    }
}