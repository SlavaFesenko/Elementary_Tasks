using System.IO;

namespace Task6LuckyTickets
{
    public class Validator
    {
        public static bool IsPathValid(string path)
        {
            return File.Exists(path);
        }
    }
}

