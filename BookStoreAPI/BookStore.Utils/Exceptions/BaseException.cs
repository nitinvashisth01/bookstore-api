using System;

namespace BookStore.Utils.Exceptions
{
    public class BaseException : Exception
    {
        #region constructors and destructor

        public BaseException() { }

        public BaseException(string message) : base(message: message) { }

        public BaseException(string message, Exception innerException) : base(message: message, innerException: innerException) { }

        #endregion
    }
}
