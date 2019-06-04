using System;
using System.Runtime.Serialization;

namespace TrianglesSorting_3
{
    [Serializable]
    internal class InvalidTriangleException : Exception
    {
        public InvalidTriangleException()
        {
        }

        public InvalidTriangleException(string message) : base(message)
        {
        }

        public InvalidTriangleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTriangleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}