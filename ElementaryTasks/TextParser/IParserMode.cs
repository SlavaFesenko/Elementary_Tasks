using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public interface IParserMode
    {
        void DoAlgorithm(string[] args);
    }
}
