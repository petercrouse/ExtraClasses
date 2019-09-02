using ExtraClasses.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace ExtraClasses.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CustomExceptionFilterAttribute>();
        }

        public override void OnException(ExceptionContext context)

        {
            if (context.Exception is OperationCanceledException)
            {
                _logger.LogInformation("Request was cancelled");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(400);

                return;
            }

            if (context.Exception is ValidationException)
            {
                _logger.LogError("Validation Exception");
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(((ValidationException)context.Exception).Failures);

                return;
            }

            if(context.Exception is TeacherDoesNotTeachSubjectException)
            {
                _logger.LogError("Teacher does not teach that subject exception");
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = GetJasonExceptionResult(context);

                return;
            }


            _logger.LogError("Something went wrong");
            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (context.Exception is TeacherDoesNotTeachSubjectException)
            {
                code = HttpStatusCode.BadRequest;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = GetJasonExceptionResult(context);
        }

        private JsonResult GetJasonExceptionResult(ExceptionContext context)
        {
            return new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
