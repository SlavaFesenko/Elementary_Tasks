using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Parser
{
    public class Validator
    {
        static public bool IsPathValid(string path)
        {
            return File.Exists(path);
        }

    }
}
