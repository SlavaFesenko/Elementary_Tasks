using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8FibonacciNumbers
{
    public class InputModel
    {
        public int LeftNumber { get; set; }
        public int RightNumber { get; set; }

        public InputModel(string[] args)
        {
            if (args.Length == 2)
            {
                args[0] = args[0].Trim(new char[] { ',' });

                if (int.TryParse(args[0], out int left) && int.TryParse(args[1], out int right))
                {
                    LeftNumber = left;
                    RightNumber = right;
                }
                else throw new ArgumentException("Values is not integer");
            }
        }
    }
}
