using System;
using System.Net;
using BookStore.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public CustomExceptionFilter()
        {

        }

        #region Implementation of IExceptionFilter

        /// <inheritdoc />
        public void OnException(ExceptionContext context)
        {
            var realException = GetRealException(context.Exception);
            var httpCode = HttpStatusCode.InternalServerError;

            var error = new ErrorDto
            {
                Code = realException.GetType().Name,
                Message = realException.Message
            };

            switch (realException)
            {
                case BadRequestException badRequestException:
                    httpCode = HttpStatusCode.BadRequest;
                    error.Code = httpCode.ToString();
                    break;
                case NotFoundException _:
                    httpCode = HttpStatusCode.NotFound;
                    error.Code = httpCode.ToString();
                    break;
                case InternalServerErrorException _:
                    error.Code = httpCode.ToString();
                    break;
                default:
                    httpCode = HttpStatusCode.InternalServerError;
                    error.Message = "An error has occurred. Please report this error to your Support team";
                    break;
            }

            context.Result = new JsonResult(error)
            {
                StatusCode = (int) httpCode,
                ContentType = "application/json"
            };
        }

        private Exception GetRealException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetRealException(ex.InnerException);
            }

            return ex;
        }

        #endregion
    }
}
