using System;
using System.IO;

namespace Task4FileParser
{
    public static class Validator
    {
        public static bool IsValid(string[] args, out WorkMode mode)
        {
            switch (args.Length)
            {
                case (int)WorkMode.Find:
                    if (File.Exists(args[0]))
                    {
                        mode = WorkMode.Find; //detect mode
                        return true;
                    }
                    else throw new ArgumentException($"File is not exist at the target directory");

                case (int)WorkMode.Replace:
                    if (File.Exists(args[0]))
                    {
                        mode = WorkMode.Replace;
                        return true;
                    }
                    else throw new ArgumentException($"File is not exist at the target directory");

                default:
                    throw new ArgumentException($"Count of input values = {args.Length}. Count values must be = 2 or 3.");
            }
        }
    }
}