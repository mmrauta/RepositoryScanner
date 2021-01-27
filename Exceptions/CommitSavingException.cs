using System;
using System.Runtime.Serialization;

namespace RepositoryScanner.Exceptions
{
    [Serializable]
    internal class CommitSavingException : Exception
    {
        public CommitSavingException()
        {
        }

        public CommitSavingException(string message) : base(message)
        {
        }

        public CommitSavingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommitSavingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}