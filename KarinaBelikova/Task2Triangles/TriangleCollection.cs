using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApp 
{
    class TriangleCollection : List<Triangle>
    {
        private Triangle[] triangles;

        public Triangle this[int index]
        {
            get { return triangles[index]; }            
            set { triangles[index] = value; }
        }


    }
}
