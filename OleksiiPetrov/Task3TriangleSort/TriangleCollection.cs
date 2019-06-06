using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3TriangleSort
{
    public class TriangleCollection
    {
        private List<Triangle> _triangleList;

        public TriangleCollection()
        {
            _triangleList = new List<Triangle>();
        }
       
        public void AddTriangle(params Triangle[] triangles)
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                _triangleList.Add(triangles[i]);
            }
        }

        public void RemoveTriangle(Triangle triangleToRemove)
        {
            if (_triangleList.Contains(triangleToRemove))
            {
                _triangleList.Remove(triangleToRemove);
            }
            else
            {
                Console.WriteLine("Triangle isn't exist in the collection");
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (_triangleList.Count != 0)
            {
                for (int i = 0; i < _triangleList.Count; i++)
                {
                    result += string.Format($"{i+1}.{_triangleList[i].ToString()}\n");
                }
                return result;
            }
            else
            {
                return $"No elements in the collection.";
            }
        }

        public void SortBySquare()
        {
            _triangleList.Sort(new TrianglesComparer());
        }

        // indexator
        public Triangle this[int index]
        {
            get
            {
                return _triangleList[index];
            }
            set
            {
                _triangleList[index] = value;
            }
        }
        
    }
}
