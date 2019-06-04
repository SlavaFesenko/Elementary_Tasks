using System;
using System.Runtime.Serialization;

namespace Envelops_2
{
    [Serializable]
    internal class CantCompareException : Exception
    {
        public CantCompareException()
        {
        }

        public CantCompareException(string message) : base(message)
        {
        }

        public CantCompareException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantCompareException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}