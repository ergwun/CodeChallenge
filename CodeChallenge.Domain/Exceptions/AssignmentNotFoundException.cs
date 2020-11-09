using System;

namespace CodeChallenge.Domain.Exceptions
{
    [Serializable]
    public class AssignmentNotFoundException : Exception
    {
        public AssignmentNotFoundException() { }
        public AssignmentNotFoundException(string message) : base(message) { }
        public AssignmentNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected AssignmentNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
