using System;

namespace CodeChallenge.Domain
{
    [Serializable]
    public class SalespersonNotFoundException : Exception
    {
        public SalespersonNotFoundException() { }
        public SalespersonNotFoundException(string message) : base(message) { }
        public SalespersonNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected SalespersonNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
