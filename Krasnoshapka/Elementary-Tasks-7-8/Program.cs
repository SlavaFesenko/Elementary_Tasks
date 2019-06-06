using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_Tasks_7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UIConsoleRun.BuildUI(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.Message);
            }
        }
    }
}
