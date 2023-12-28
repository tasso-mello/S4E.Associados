namespace api.S4E.Associados.Structure.Exceptions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Net;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptions : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptions> _logger;

        public CustomExceptions(ILogger<CustomExceptions> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NullReferenceException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    new
                    {
                        type = "NullReferenceException",
                        error = new
                        {
                            message = context.Exception.InnerException?.Message ?? context.Exception.Message,
                        }
                    }
                );
            }
            else if ((context.Exception is NotImplementedException))
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(
                    new
                    {
                        type = "NotImplementedException",
                        error = new
                        {
                            message = context.Exception.InnerException?.Message ?? context.Exception.Message,
                        }
                    }
                );
            }
            else if (context.Exception is Exception)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(
                    new
                    {
                        type = "Exception",
                        error = new
                        {
                            message = context.Exception.InnerException?.Message ?? context.Exception.Message,
                        }
                    }
                );
            }

            _logger.LogError(context.Exception.InnerException?.Message ?? context.Exception.Message);
        }
    }
}
