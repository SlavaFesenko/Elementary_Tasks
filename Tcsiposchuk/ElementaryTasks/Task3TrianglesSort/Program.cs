using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TrianglesSort
{
    class Program
    {
        static void Main()
        {
            Controller application = new Controller();

            UI.ShowInstruction();
            while(!application.IsSuccessful)
            {
                application.Run();
            }
            application.ShowResult();

            Console.ReadLine();

        }
    }
}
