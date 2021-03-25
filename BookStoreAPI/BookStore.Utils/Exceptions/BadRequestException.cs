using System;

namespace BookStore.Utils.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message: message) { }

        public BadRequestException(string message, Exception innerException) : base(message: message, innerException: innerException) { }
    }
}
