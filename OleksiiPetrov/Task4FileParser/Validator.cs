using System;
using System.IO;

namespace Task4FileParser
{
    public static class Validator
    {
        public static bool IsValid(string[] args)
        {
            switch (args.Length)
            {
                case (int)WorkMode.Find:
                        return true;

                case (int)WorkMode.Replace:
                        return true;

                default:
                    throw new ArgumentException($"Count of input values = {args.Length}. Count values must be = 2 or 3.");
            }
        }

        public static bool IsFileExists(string[] args)
        {
            if (File.Exists(args[0]))
            {
                return true;
            }
            else throw new ArgumentException($"File is not exist at the target directory");
        }
    }
}