using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3_TriangleSorting
{
    class TriangleList : IEnumerable<Triangle>, IEnumerator<Triangle>, IComparable<Triangle>
    {
        private List<Triangle> triangleList = new List<Triangle>();
        public Triangle Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Add(Triangle newTriangle)
        {
            this.triangleList.Add(newTriangle);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Triangle> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            foreach (Triangle triangle in triangleList)
            {
                //TODO:out type
                string measure = String.Concat(triangle.PerimeterMeasure, "2");
                Console.WriteLine(@"[Triangle {0}: {1} {2}]",
                    triangle.Name, triangle.Square, measure);
            }
        }

        public int CompareTo(Triangle other)
        {
            throw new NotImplementedException();
        }
    }
}
