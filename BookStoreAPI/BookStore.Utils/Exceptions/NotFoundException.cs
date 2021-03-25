using System;

namespace BookStore.Utils.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message: message) { }

        public NotFoundException(string message, Exception innerException) : base(message: message, innerException: innerException) { }
    }
}
