using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort.UI
{
    public static class ConsoleUI
    {
        #region Private Field

        private static string outputMessage = "============= Triangles list: ===============";

        #endregion

        #region Method
        public static void BuildUI(TriangleCollection trianglesList)
        {
            Console.WriteLine(outputMessage);
            Console.WriteLine(trianglesList);
        }

        #endregion
    }
}
