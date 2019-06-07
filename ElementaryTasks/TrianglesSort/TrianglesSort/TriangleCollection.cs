using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesSort
{
    public class TriangleCollection
    {
        #region Prt Field

        private List<Triangle> _triangleList = new List<Triangle>();

        #endregion

        #region Methods

        public void Add(params Triangle[] triangles)
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                _triangleList.Add(triangles[i]);
            }
        }        

        public override string ToString()
        {
            string result = string.Empty;
            int counter = 0;

            foreach (var triangle in _triangleList.OrderByDescending(t=>t.Square))
            {
                result += $"{++counter}.{triangle}\n";
            }
            if (result == string.Empty)
            {
                result = "Doesn't have elements in the collection!";
            }

            return $"{result}\n";
        }

        #endregion
    }
}
