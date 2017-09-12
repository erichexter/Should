using System;

namespace Should.Core.Exceptions
{
    /// <summary>
    /// Exception to be thrown from <see cref="IMethodInfo.Invoke"/> when the number of
    /// parameter values does not the test method signature.
    /// </summary>
    public class ParamterCountMismatchException : Exception
    {
        /// <summary/>
        public ParamterCountMismatchException() { }

        /// <summary/>
//        protected ParamterCountMismatchException(SerializationInfo info, StreamingContext context): base(info, context) { }
    }
}