using System;
using System.Runtime.Serialization;

namespace RepositoryScanner.Exceptions
{
    [Serializable]
    internal class GitHubCommunicationException : Exception
    {
        public GitHubCommunicationException()
        {
        }

        public GitHubCommunicationException(string message) : base(message)
        {
        }

        public GitHubCommunicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GitHubCommunicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}