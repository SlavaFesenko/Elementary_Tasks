using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class Parser:IParserMode
    {
        #region Prvt Field

        public IParserMode Mode { get; private set; }

        #endregion

        #region Ctor

        public Parser(Mode mode)
        {
            if (mode == TextParser.Mode.FindAndCount)
                Mode = new PatternCounter();
            else if (mode == TextParser.Mode.FindAndReplace)
                Mode = new PatternReplacer();
        }

        #endregion

        #region Methods
      
        public void DoAlgorithm(string[] args)
        {
            Mode.DoAlgorithm(args);
        }

        #endregion
    }
}
