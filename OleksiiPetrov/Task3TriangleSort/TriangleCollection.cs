using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TriangleSort
{
    public class TriangleCollection
    {
        private List<Triangle> triangleList;

        public TriangleCollection()
        {
            triangleList = new List<Triangle>();
        }
       
        public void AddTriangle(params Triangle[] triangles)
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                triangleList.Add(triangles[i]);
            }
        }

        public void RemoveTriangle(Triangle triangleToRemove)
        {
            if (triangleList.Contains(triangleToRemove))
            {
                triangleList.Remove(triangleToRemove);
            }
            else
            {
                Console.WriteLine("Triangle isn't exist in the collection");
            }
        }

        public override string ToString()
        {
            string result = null;
            if (triangleList.Count != 0)
            {
                for (int i = 0; i < triangleList.Count; i++)
                {
                    result += string.Format($"{i+1}.{triangleList[i].ToString()}\n");
                }
                return result;
            }
            else
            {
                return string.Format("No elements in the collection.");
            }
        }

        public void SortBySquare()
        {
            triangleList.Sort(new TrianglesComparer());
        }

        // indexator
        public Triangle this[int index]
        {
            get
            {
                return triangleList[index];
            }
            set
            {
                triangleList[index] = value;
            }
        }
        
    }
}
