using System;
using System.Runtime.Serialization;

namespace LuckyTickets_6
{
    [Serializable]
    internal class CaseNotFoundException : Exception
    {
        public CaseNotFoundException()
        {
        }

        public CaseNotFoundException(string message) : base(message)
        {
        }

        public CaseNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CaseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}