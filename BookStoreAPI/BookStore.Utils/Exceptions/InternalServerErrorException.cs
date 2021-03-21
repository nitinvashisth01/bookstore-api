using System;

namespace BookStore.Utils.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException(string message) : base(message: message) { }

        public InternalServerErrorException(string message, Exception innerException) : base(message: message, innerException: innerException) { }
    }
}
